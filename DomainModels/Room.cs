using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    private enum Status
    {
        available,
        underMaintenece,
        needsCleaning

    }

    internal class Room
    {

        private int Id {  get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        private List<DateTime> BookedDays { get; set; } = new List<DateTime>();


    }
}
