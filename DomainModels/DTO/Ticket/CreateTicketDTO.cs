using DomainModels;
using DomainModels.DB;

namespace DomainModels.DTO
{
    //this is only an example DTO and might need to be modified in the near future
    public class CreateTicketDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }
        public List<Message> Messages { get; set; }
    }
    public enum Status
    {
        WorkInProgress,
        ClosedCompleted,
        ClosedSkipped

    }
}
