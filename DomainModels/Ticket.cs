using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Ticket
    {
       public int Id { get; set; }
       public string Title { get; set; }
        public string Description { get; set; }
        public Status status { get; set; }

        public Message message { get; set; }


    }

    public enum Status
    {
        WorkInProgress,
        ClosedCompleted, 
        ClosedSkipped 
    
    }
}
