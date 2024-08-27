using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime TimeMessageSent { get; set; }
        public User userID { get; set; }
        public string message { get; set; }
    }
}
