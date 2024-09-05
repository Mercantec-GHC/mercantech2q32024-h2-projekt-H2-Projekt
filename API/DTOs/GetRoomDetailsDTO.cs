using DomainModels;

namespace API.DTOs
{
    public class GetRoomDetailsDTO
    {
        public int Rooms { get; set; }   // Nullable int
        public int RoomNumber { get; set; }
        public string? Beds { get; set; }
        public decimal Price { get; set; }   // Nullable decimal
        public string? Status { get; set; }
        public string? Condition { get; set; }
    }

}
