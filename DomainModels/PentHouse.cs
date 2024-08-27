using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class PentHouse : RoomType
    {
        public int Id { get; set; }
        public List<string> facilitates = new List<string>()
        {
            "King-size seng", "stort badeværelse med badekar og separat bruser", "opholdsstue", "TV", "skrivebord", "minibar", "Wi-Fi", "privat terrasse med udsigt"
        };
        public decimal PricePerNight = 3000; 
    }
}
