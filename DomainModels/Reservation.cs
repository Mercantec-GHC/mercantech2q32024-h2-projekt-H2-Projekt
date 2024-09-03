﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Reservation
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public Customer Customer { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Extra> Extras { get; set; }
    }
}
