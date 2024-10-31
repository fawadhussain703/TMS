using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tms.Models;
using Tms.Service.Vehicle;

namespace Tms.Controllers
{
    
    public class VehicleController : Controller
    {
        private readonly VehicleService _vehicleService;

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
    }

}