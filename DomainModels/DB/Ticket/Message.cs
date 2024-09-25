using System.ComponentModel.DataAnnotations;

namespace DomainModels.DB
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeMessageSent { get; set; }
        public User User { get; set; }
        public Ticket Ticket { get; set; }
        public string MessageText { get; set; }
    }
}
