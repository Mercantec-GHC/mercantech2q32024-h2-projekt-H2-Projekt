using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Administrator : Receptionist
    {
        public int id { get; set; }
        public void DeleteAnyAccount() { }
        public void AddAnyAccount() { }
        public void CreateRoom() { }
        public void ViewOccupancyReport() { }

    }
}
