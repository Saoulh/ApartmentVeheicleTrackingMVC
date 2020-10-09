using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppVehicles.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppVehicles.Controllers
{
    public class VehicleController : Controller
    {
        private IMakesRepo _makesRepo;
        private IVehicleRepo _vehicleRepo;
        private IModelRepo _modelRepo;
        private IOwnerRepo _ownereRepo;

        public VehicleController(IMakesRepo makesRepo,
            IVehicleRepo vehicleRepo,
            IModelRepo modelRepo,
            IOwnerRepo ownereRepo
            )
        {
            this._makesRepo = makesRepo;
            this._vehicleRepo = vehicleRepo;
            this._modelRepo = modelRepo;
            this._ownereRepo = ownereRepo;
        }
        public IActionResult Index()
        {

            List<VehicleOwnerViewModel> model = new List<VehicleOwnerViewModel>();
            _vehicleRepo.GetVehicles().ToList().ForEach(v =>
            {
                VehicleOwnerViewModel vehicle = new VehicleOwnerViewModel
                {
                    VehicleId = v.VehicleId,
                    OwnersName = v.OwnersName,
                    Make = v.Make,
                    Model = v.Model,
                    Color =v.Color,
                    Registration = v.Registration,
                    DateRegistered = v.DateRegistered
                };
                model.Add(vehicle);
            });
            return View(model);


        }
        public IActionResult AddVehicle()
        {

            VehicleViewModel model = new VehicleViewModel();
            model.DateRegistered = DateTime.Now;

            List<SelectListItem> owners = _ownereRepo.GetOwners()
                       .Select(o =>
                       new SelectListItem
                       {
                           Value = o.OwnerID.ToString(),
                           Text = o.FirstName + " " + o.LastName
                       }).ToList();
            model.Owner = new SelectList(owners, "Value", "Text");

            List<SelectListItem> makes = _makesRepo.GetMakes()
                      .Select(o =>
                      new SelectListItem
                      {
                          Value = o.MakeId.ToString(),
                          Text = o.Make
                      }).ToList();
            model.Make = new SelectList(makes, "Value", "Text");

            return View(model);
        }
        [HttpPost]
        public IActionResult AddVehicle(VehicleViewModel model )
        {

            if(ModelState.IsValid)
            {

                if (_vehicleRepo.AddVehicle(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Error in Saving Vehicle");
                }
                
            }

            List<SelectListItem> owners = _ownereRepo.GetOwners()
                       .Select(o =>
                       new SelectListItem
                       {
                           Value = o.OwnerID.ToString(),
                           Text = o.FirstName + " " + o.LastName
                       }).ToList();
            model.Owner = new SelectList(owners, "Value", "Text");

            List<SelectListItem> makes = _makesRepo.GetMakes()
                      .Select(o =>
                      new SelectListItem
                      {
                          Value = o.MakeId.ToString(),
                          Text = o.Make
                      }).ToList();
            model.Make = new SelectList(makes, "Value", "Text");

            return View(model);
        }
        public IActionResult getModels(int id)
        {
            var models = _modelRepo.GetMakeModels(id).ToList();
            models.Insert(0, new BusinessEntities.Models() { Model = "-- Select --", ModelId = 0 });

            return Json(models);
        }

    }
}