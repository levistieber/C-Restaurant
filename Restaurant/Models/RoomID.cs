using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class TableID
    {
        public int FloorNumber { get; }
        public int TableNumber { get; }

        public TableID(int floorNumber, int tableNumber)
        {
            FloorNumber = floorNumber;
            TableNumber = tableNumber;
        }

        public override string ToString()
        {
            return $"{FloorNumber}{TableNumber}";
        }

        public override bool Equals(object obj)
        {
            return obj is TableID tableID &&
                FloorNumber == tableID.FloorNumber &&
                TableNumber == tableID.TableNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FloorNumber, TableNumber);
        }

        public static bool operator ==(TableID tableID1, TableID tableID2)
        {
            if(tableID1 is null && tableID2 is null)
            {
                return true;
            }

            return !(tableID1 is null) && tableID1.Equals(tableID2);
        }

        public static bool operator !=(TableID tableID1, TableID tableID2)
        {
            return !(tableID1 == tableID2);
        }

    }
}
