using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Collections; //Required by IEnumerable
#endregion

namespace eRestaurantSystem.DAL.DTOs
{
    public class ReservationByDate
    {
        public string Description { get; set; }
        // The rest of the data will be a collection of POCO rows
        // The actual POCO will be defined in the Linq query
        public IEnumerable Reservations { get; set; }
    }
}
