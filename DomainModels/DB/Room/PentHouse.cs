using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.DB
{
    public class PentHouse : RoomType
    {
        public PentHouse()
        {
            PricePerNight = 3000;
            RoomTypeName = "Penthouse";
            Tags = new List<string>()
            {
                "King-size seng", "stort badeværelse med badekar og separat bruser", "opholdsstue", "TV", "skrivebord", "minibar", "Wi-Fi", "privat terrasse med udsigt"
            };
        }
    }
}
