using System.ComponentModel.DataAnnotations;

namespace DomainModels.DB
{
    public class Extra
    {
        [Key]
        public int Id { get; set; }
        public string ExtraName { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
