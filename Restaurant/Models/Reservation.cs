using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Reservation
    {
        public TableID TableID { get; }
        public string Name { get; }
        public DateTime ResTime { get; }


        public Reservation(TableID tableID, string name,  DateTime resTime)
        {
            TableID = tableID;
            Name = name;
            ResTime = resTime;
        }
    }
}
