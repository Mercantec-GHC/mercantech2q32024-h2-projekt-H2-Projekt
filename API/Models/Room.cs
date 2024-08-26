using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    enum Status
    {
        available,
        underMaintenece,
        needsCleaning

    }

    internal class Room
    {

        
        public string type { get; set; }
        public int price { get; set; }

        private List<DateTime> bookedDays { get; set; } = new List<DateTime>();

        Status status { get; set; }
        
    }
}
