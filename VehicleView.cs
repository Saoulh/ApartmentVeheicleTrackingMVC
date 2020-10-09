using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
   
        public class VehicleView
        {
            public int VehicleId { get; set; }
            public string OwnersName { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public string Registration { get; set; }
            public DateTime DateRegistered { get; set; }
        }

   
}
