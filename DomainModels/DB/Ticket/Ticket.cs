using System.ComponentModel.DataAnnotations;

namespace DomainModels.DB
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status status { get; set; }

        public List<Message> Messages { get; set; }


    }

    public enum Status
    {
        WorkInProgress,
        ClosedCompleted,
        ClosedSkipped

    }
}
