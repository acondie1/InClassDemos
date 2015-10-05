using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.DAL.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel;        //used for ODS access
using eRestaurantSystem.DAL.DTOs;
using eRestaurantSystem.DAL.POCOs; 
#endregion

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class AdminController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> SpecialEvent_List()
        {
            using (var context = new eRestaurantContext())
            {   
                //retrieve the data from the SpecialEvents table on sql                /             connect to our DbContext class in the DAL
                //to do so we will use the DbSet in eRestaurantContext                 /             create an instance of the class
                //call SpecialEvents (done by mapping)                                 /             we will use a transaction to hold our query

                //method syntax
                //return context.SpecialEvents.OrderBy(x => x.Description).ToList();

                //query syntax 
                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select item;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> GetReservationsByEventCode(string eventcode)
        {
            using (var context = new eRestaurantContext())
            {
                //query syntax 
                var results = from item in context.Reservations
                              where item.EventCode.Equals(eventcode)
                              orderby item.CustomerName, item.ReservationDate
                              select item;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ReservationByDate> GetReservationsByDate(string reservationDate)
        {
            using (var context = new eRestaurantContext())
            {
                //REMEMBER: Linq does NOT like using DateTime casting
                int theYear = (DateTime.Parse(reservationDate)).Year;
                int theMonth = (DateTime.Parse(reservationDate)).Month;
                int theDay = (DateTime.Parse(reservationDate)).Day;

                //query syntax
                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select new ReservationByDate  //DTO
                              {
                                  Description = item.Description,
                                  Reservations = from row in item.Reservations  // collection of navigated rows of ICollection in SpecialEvent entity
                                                 where row.ReservationDate.Year == theYear &&
                                                        row.ReservationDate.Month == theMonth &&
                                                        row.ReservationDate.Day == theDay
                                                 select new ReservationDetail()     //POCO
                                                 {
                                                     CustomerName = row.CustomerName,
                                                     ReservationDate = row.ReservationDate,
                                                     NumberInParty = row.NumberInParty,
                                                     ContactPhone = row.ContactPhone,
                                                     ReservationStatus = row.ReservationStatus
                                                 }
                              };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CategoryMenuItems> GetCategoryMenuItems_List()
        {
            using (var context = new eRestaurantContext())
            {
                //query syntax
                var results = from category in context.MenuCategories
                              select new CategoryMenuItems()  //DTO
                              {
                                  Description = category.Description,
                                  MenuItems = from row in category.MenuItems  // collection of navigated rows of ICollection in SpecialEvent entity                                 
                                                 select new MenuItem()     //POCO
                                                 {
                                                     Description = row.Description,
                                                     Price = row.CurrentPrice,
                                                     Calories = row.Calories,
                                                     Comment = row.Comment
                                                 }
                              };
                return results.ToList();
            }
        }
    }
}
