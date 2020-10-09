using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppVehicles.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddOwner()
        {

           // VehicleViewModel model = new VehicleViewModel();
           
         
            return View();
        }
    }
}
