using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AppVehicles.Models
{
    public class VehicleOwnerViewModel
    {
        public int VehicleId { get; set; }
        [DisplayName("Owners Name")]
        public string OwnersName { get; set; }
        [DisplayName("Make")]
        public string Make { get; set; }
        [DisplayName("Model")]
        public string Model { get; set; }
        [DisplayName("Color")]
        public string Color { get; set; }
        [DisplayName("Registration")]
        public string Registration { get; set; }
        [DisplayName("Date Registered")]
        public DateTime DateRegistered { get; set; }
    }
}
