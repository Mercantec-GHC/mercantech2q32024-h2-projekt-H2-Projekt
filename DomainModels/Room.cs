    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    enum Status
    {
        available,
        underMaintenece,
        needsCleaning
    }
    public class Room
    {
        public int RoomId { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public List<DateTime>? BookedDays { get; set; } = new List<DateTime>();
        Status Status { get; set; }
    }
}