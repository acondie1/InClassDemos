﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
#endregion

namespace eRestaurantSystem.DAL.Entities
{
    public class Table
    {
        [Key]
        public int TableID { get; set; }
        [Required, Range(1,25)]
        public byte TableNumber { get; set; }
        public bool Smoking { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }

        //Navigation Properties
        //The reservations table is a many to many relationship to the Tables table.
        //The SQL ReservationsTable resolves this problem, however ReservationTables holds only a compound primary key.
        //We will not create a ReservationsTable entity in our project but handle it via navigation mapping.
        //Therefore we will place a ICollection<> property in this entity referring to the Reservations table.
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Table()
        {
            Available = true;   //sets default
        }
    }
}