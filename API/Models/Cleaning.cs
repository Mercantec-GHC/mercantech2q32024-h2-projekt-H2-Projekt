using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Cleaning : Employee
    {
        public int id { get; set; }
        public void CleanRoom() { }
        public void GetRoomsToClean() { }
    }
}
