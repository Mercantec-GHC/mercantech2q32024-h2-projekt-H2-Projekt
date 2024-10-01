using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.DB
{
    public class Employee : User
    {
        public int Id { get; set; }
        public string UPN { get; set; }
        public Department Department { get; set; }
        public string EmployeePhoneNumber { get; set; }

    }
}
