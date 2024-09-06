using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.DTO;
using DomainModels.DB;

namespace DomainModels.DB
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime TimeMessageSent { get; set; }
        public User User { get; set; }
        public Ticket Ticket { get; set; }
        public string MessageText { get; set; }
    }
}
