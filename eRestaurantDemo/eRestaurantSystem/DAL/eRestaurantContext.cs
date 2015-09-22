using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.DAL.Entities;
using System.Data.Entity;
#endregion

namespace eRestaurantSystem.DAL
{
    //this class should be restricted to access by ONLY the BLL methods.
    //This class should NOT be accessible outside of the component library

    //This class inherits DbContext
    internal class eRestaurantContext : DbContext
    {
        public eRestaurantContext()
            : base("name =EatIn")
        {
            //constructor is used to pass web config string name
        }

        //setup the DbSet Mappings
        //One DbSet for each entity I create
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }

        //When overriding OnModelCreating(), it is important to remember to call the base method's implementation before you exit the method

        //The ManyToManyNavigationPropertyConfiguration.Map method lets you configure the tables and columns used for many-to-many relationships
        //It takes a ManyToManyNavigationPropertyConfiguration instance in which you specify the column names by calling the MapLeftKey, MapRightKey, and ToTable Methods.

        //The "left" key is the one specified in the HasMany method. The "right" key is the one specified in the WithMany method

        //We have a many to many relationship between reservation and tables. A reservation may need many tables. A table can have many reservations over time.

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.
                Entity<Reservation>().
                HasMany(r => r.Tables).
                WithMany(x => x.Reservations).
                Map(mapping =>
                {
                    mapping.ToTable("ReservationTables");
                    mapping.MapLeftKey("TableID");
                    mapping.MapRightKey("ReservationID");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}