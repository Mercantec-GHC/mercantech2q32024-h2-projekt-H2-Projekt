using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.DB
{
    public class StandardHouse
    {
        public int Id { get; set; }
        public List<string> facilitates = new List<string>()
        {
            "Enkeltseng eller dobbeltseng", "badeværelse med bruser", "TV", "skrivebord", "Wi-Fi"
        };
        public decimal PricePerNight;

        public string NumberOfRooms { get; set; }

        public decimal CalRoomPrice(StandardHouse rooms)
        {
            if (rooms.NumberOfRooms == "single room")
            {
                rooms.PricePerNight = 500;
            }
            else if (rooms.NumberOfRooms == "double room")
            {
                rooms.PricePerNight = 800;
            }
            else
            {
                rooms.PricePerNight = 0;
            }
            return rooms.PricePerNight;
        }
    }
}
