using BusinessEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppVehicles.Models
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }
        [DisplayName("Owners Name")]
        [Required(ErrorMessage = "Please select an Owner")]
        public int? OwnerId { get; set; }
        [DisplayName("Make")]
        [Required(ErrorMessage = "Please select a vehicle make")]
        public int? MakeId { get; set; }
        [DisplayName("Model")]
        [Required(ErrorMessage = "Please select a vehicle model")]
        public int? ModelId { get; set; }
        [DisplayName("Color")]
        public string Color { get; set; }
        [DisplayName("Registration")]
        public string Registration { get; set; }
        [DisplayName("Date Registered")]
        public DateTime DateRegistered { get; set; }

        
        public IEnumerable<SelectListItem> Owner { get; set; }
        public IEnumerable<SelectListItem> Make { get; set; }
        public IEnumerable<SelectListItem> Model { get; set; }

        public static implicit operator Vehicles(VehicleViewModel model)
        {
            return new Vehicles
            {
                OwnerId = model.OwnerId ?? 0,
                MakeID = model.MakeId ?? 0,
                ModelId = model.ModelId ?? 0,
                Color = model.Color,
                Registration = model.Registration,
                DateRegistered = model.DateRegistered
            };
       }
    }
}
