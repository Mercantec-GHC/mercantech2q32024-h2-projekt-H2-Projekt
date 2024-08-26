using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Room
    {
        public List<string> RoomType { get; set; }
        public int Rooms { get; set; }
        public int RoomNumber { get; set; }
        public string Beds { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Condition { get; set; }
    }
}