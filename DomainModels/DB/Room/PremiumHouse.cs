using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.DB
{
    public class PremiumHouse
    {
        public int Id { get; set; }
        public List<string> facilitates = new List<string>()
        {
            "Dobbeltseng", "badeværelse med badekar og bruser", "TV", "skrivebord", "minibar", "Wi-Fi", "balkon"
        };
        public decimal PricePerNight;

        public string numberOfRooms { get; set; }
        public decimal CalRoomPrice(PremiumHouse rooms)
        {
            if (rooms.numberOfRooms == "single room")
            {
                rooms.PricePerNight = 900;
            }
            else if (rooms.numberOfRooms == "double room")
            {
                rooms.PricePerNight = 1200;
            }
            else
            {
                rooms.PricePerNight = 0;
            }
            return rooms.PricePerNight;
        }
    }


}
