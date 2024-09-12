using System.ComponentModel.DataAnnotations;

namespace DomainModels.DB
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public RoomType RoomType { get; set; }
        public int Rooms { get; set; }
        public int RoomNumber { get; set; }
        public string Beds { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Condition { get; set; }

        public string Description { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}