using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using Tms.Data.AppContext;
using Tms.Models;
using Tms.Service.Vehicle;

namespace Tms.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly VehicleService _vehicleService;

        public VehicleController()
        {
            
        }

        public VehicleController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();
            var list = _vehicleService.GetVehicles(userId);


            var data = list.Select(x => new VehicleViewModel
            {
                UserId = x.UserId,
                VehicleId = x.VehicleId,
                CreatedDate = x.CreatedDate,
                Make = x.Make,
                Model = x.Model,
                Year = x.Year,
                VehicleNumber = x.VehicleNumber,






            }).ToList();

            return View(data);
        }

        public ActionResult AddVehicle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddVehicle(VehicleViewModel v)
        {
            if (ModelState.IsValid)
            {

                var vehicle = new Vehicles
                {
                    VehicleNumber = v.VehicleNumber,
                    Make = v.Make,
                    Model = v.Model,
                    Year = v.Year,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    UserId = User.Identity.GetUserId()
                };




                string result = _vehicleService.SaveVehicles(vehicle);
                if (result.StartsWith("Error"))
                {
                    
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, result);
                }

                return RedirectToAction("List");
            }
            var errors = ModelState.Values.SelectMany(ve => ve.Errors)
                .Select(e => e.ErrorMessage);
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, string.Join(", ", errors));


        }
    }

}