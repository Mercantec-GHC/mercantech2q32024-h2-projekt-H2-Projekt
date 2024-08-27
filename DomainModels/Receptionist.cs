using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Receptionist : Employee
    {
        public int id { get; set; }
        public void CheckIn() { }
        public void CheckOut() { }
        public void DeleteAnyBooking() { }
        public void EditAnyBooking() { }
        public void CreateAnyBooking() { }

    }
}
