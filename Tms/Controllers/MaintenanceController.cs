using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tms.Core;
using Tms.Models;
using Tms.Service.Maintenance;


namespace Tms.Controllers
{
    [Authorize]
    public class MaintenanceController : Controller
    {
        private readonly MaintenanceService _maintenanceService;

        public MaintenanceController()
        {

        }

        public MaintenanceController(MaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();
            var list = _maintenanceService.GetMaintenanceList(userId);

            var data = list.Select(x => new MaintenanceViewModel()
            {
                UserId = x.UserId,
                VehicleId = x.VehicleId,
                CreatedDate = x.CreatedDate,
                ApprovalStatus = Tms.Core.Constant.GetEnumDescription((ApprovalStatus)x.ApprovalStatus),
                VehicleNumber = x.Vehicle.VehicleNumber ,
                VehicleMake = x.Vehicle.Make,
                VehicleModel = x.Vehicle.Model,
                VehicleDescription = x.Description,
                DocumentURL = x.DocumentUrl,
                VehicleYear=x.Vehicle.Year,





            }).ToList();


            return View(data);
        }
    }
}