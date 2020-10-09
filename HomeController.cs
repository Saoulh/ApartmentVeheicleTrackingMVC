using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppVehicles.Models;

namespace AppVehicles.Controllers
{
    public class HomeController : Controller
    {
       

        public HomeController()
        {
           
        }
        public IActionResult Index()
        {

           
            return View();


        }

        

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
