using DomainModels;

namespace DomainModels.DTO
{
    public class GetRoomDetailsDTO
    {
        public int Rooms { get; set; }
        public int RoomNumber { get; set; }
        public string? Beds { get; set; }
        public decimal Price { get; set; }
        public string? Status { get; set; }
        public string? Condition { get; set; }
    }

}
