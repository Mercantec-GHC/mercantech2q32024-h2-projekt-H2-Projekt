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
    [Table("rooms")]
    public class Room
    {
        [Column("type")]
        public string Type { get; set; }
        [Column("price")]
        public int Price { get; set; }
        [Column("booked_days")]
        public List<DateTime> BookedDays { get; set; } = new List<DateTime>();
        [Column("status")]
        Status Status { get; set; }
        
    }
}
