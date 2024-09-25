using System.ComponentModel.DataAnnotations;

namespace DomainModels.DTO
{
    public class ModifyReservationDTO
    {
        [Required]
        public int ReservationId { get; set; }

        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
