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
        #region Query Samples
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
        public List<Waiter> Waiters_List()
        {
            using (var context = new eRestaurantContext())
            {
                //query syntax 
                var results = from item in context.Waiters
                              orderby item.LastName, item.FirstName
                              select item;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Waiter GetWaiterByID(int waiterid)
        {
            using (var context = new eRestaurantContext())
            {
                //query syntax
                var results = from item in context.Waiters
                              where item.WaiterID == waiterid
                              select item;
                              
                return results.FirstOrDefault();
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
        #endregion

        #region CRUD Insert, Update, Delete
        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public void SpecialEvents_Add(SpecialEvent item)
        {
            //input into this method is at the instance level
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //create a pointer variable for the instance type.
                //Set this pointer to null.
                SpecialEvent added = null;

                //Set up the add request for the dbcontext
                added = context.SpecialEvents.Add(item);

                //Saving the changes will cause the .Add to execute (delayed execution)
                //Commits the add to the database
                //Evaluates the annotations (validation) on your entity
                context.SaveChanges();
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Update,false)]
        public void SpecialEvents_Update(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State =
                    System.Data.Entity.EntityState.Modified;               
 
                context.SaveChanges();
            }
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete,false)]
        public void SpecialEvents_Delete(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //lookup the item instance on the database to determine if the instance exists
                //ensure you reference the PK field name (item.EVENTCODE)
                SpecialEvent existing = context.SpecialEvents.Find(item.EventCode);
                
                //set up the delete request command
                context.SpecialEvents.Remove(existing);
                
                //commit the action to happen
                context.SaveChanges();
            }
        }

        //Waiter CRUD
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void Waiter_Add(Waiter item)
        {
            //input into this method is at the instance level
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //create a pointer variable for the instance type.
                //Set this pointer to null.
                Waiter added = null;

                //Set up the add request for the dbcontext
                added = context.Waiters.Add(item);

                //Saving the changes will cause the .Add to execute (delayed execution)
                //Commits the add to the database
                //Evaluates the annotations (validation) on your entity
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Waiter_Update(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<Waiter>(context.Waiters.Attach(item)).State =
                    System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Waiter_Delete(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //lookup the item instance on the database to determine if the instance exists
                //ensure you reference the PK field name (item.EVENTCODE)
                Waiter existing = context.Waiters.Find(item.WaiterID);

                //set up the delete request command
                context.Waiters.Remove(existing);

                //commit the action to happen
                context.SaveChanges();
            }
        }
        #endregion
    }   //eof class
}   //eof namespace
