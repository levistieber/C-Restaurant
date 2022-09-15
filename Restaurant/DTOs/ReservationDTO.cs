using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DTOs
{
    public class ReservationDTO
    {
        [Key]
        public Guid Id { get; set; }
        public int FloorNumber { get; set; }
        public int TableNumber { get; set; }
        public string Name { get; set; }
        public DateTime ResTime { get; set; }
    }
}
