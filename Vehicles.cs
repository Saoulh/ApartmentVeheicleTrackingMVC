using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class Vehicles
    {
        public int VehicleId { get; set; }
        public int OwnerId { get; set; }
        public int MakeID { get; set; }
        public int ModelId { get; set; }
        public String Color { get; set; }
        public String Registration { get; set; }
        public DateTime DateRegistered { get; set; }
    }

}
