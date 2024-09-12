using DomainModels.DB;
using DomainModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Mappers
{
    //this is an example mapper used to try out some DTO stuff, dont mind it for now
    public static class TicketMapper
    {
        public static Ticket toCreateTicketDTO(this CreateTicketDTO ticketDTO)
        {
            return new Ticket
            {
                Title = ticketDTO.Title,
                Description = ticketDTO.Description,
                Messages = ticketDTO.Messages,

            };
        }
    }
}
