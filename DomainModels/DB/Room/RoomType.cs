using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DomainModels.DB
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }
        public virtual string RoomTypeName { get; set; } = "";
        public virtual decimal PricePerNight { get; set; } = 100;
        public virtual List<string> Tags { get; set; } = new List<string>();

        [JsonIgnore]
        public List<Room> Rooms { get; set; } = new List<Room>();

    }
}
