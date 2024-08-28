    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    enum Status
    {
        available,
        underMaintenece,
        needsCleaning
    }

    public class Room
    {
        public int id { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public List<DateTime> bookedDays { get; set; } = new List<DateTime>();

        Status status { get; set; }
        
    }
}
