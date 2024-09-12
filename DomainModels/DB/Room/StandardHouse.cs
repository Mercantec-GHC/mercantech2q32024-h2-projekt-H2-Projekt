using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.DB
{
    public class StandardHouse : RoomType
    {
        public StandardHouse()
        {
            PricePerNight = CalRoomPrice(this);
            RoomTypeName = "StandardHouse";
            Tags = new List<string>()
            {
                "Enkeltseng eller dobbeltseng", "badeværelse med bruser", "TV", "skrivebord", "Wi-Fi"
            };
        }

        public string NumberOfRooms { get; set; }
        public decimal CalRoomPrice(StandardHouse rooms)
        {
            if (rooms.NumberOfRooms == "single room")
            {
                return 500;
            }
            else if (rooms.NumberOfRooms == "double room")
            {
                return 800;
            }
            else
            {
                return 0;
            }
        }
    }
}
