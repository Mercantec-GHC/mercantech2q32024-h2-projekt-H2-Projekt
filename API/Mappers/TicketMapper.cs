using DomainModels.DTO;
using DomainModels;
using DomainModels.DB;
using Microsoft.AspNetCore.Authentication;

namespace API.Mappers
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
