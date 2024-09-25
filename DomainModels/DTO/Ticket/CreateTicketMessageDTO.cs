using System.ComponentModel.DataAnnotations;

namespace DomainModels.DTO
{
    public class CreateTicketMessageDTO
    {
        public DateTime TimeMessageSent { get; set; } = DateTime.Now;
        public string MessageText { get; set; } = "";
    }
}
