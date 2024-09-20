using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels;
public class PostRoomDTO
{
    public int RoomNumber { get; set; }
    public string Beds { get; set; } = null!;
    public string Type { get; set; } = null!;
    public int Price { get; set; }

}
