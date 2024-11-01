using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tms.Core;
using Tms.Data.AppContext;
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
            IEnumerable<MaintenanceActivities> list;

            if (User.IsInRole("Supervisor"))
            {
                list = _maintenanceService.GetAllMaintenance();
            }
            else
            {
                list = _maintenanceService.GetMaintenanceList(userId);
            }

            var data = list.Select(x => new MaintenanceViewModel()
            {
                UserId = x.UserId,
                VehicleId = x.VehicleId,
                CreatedDate = x.CreatedDate,
                ApprovalStatus = Tms.Core.Constant.GetEnumDescription((ApprovalStatus)x.ApprovalStatus),
                VehicleNumber = x.Vehicle.VehicleNumber,
                VehicleMake = x.Vehicle.Make + " " + x.Vehicle.Model + " " + x.Vehicle.Year,
                VehicleModel = x.Vehicle.Model,
                VehicleDescription = x.Description,
                DocumentURL = x.DocumentUrl,
                VehicleYear = x.Vehicle.Year,
                CreatedBy = x.Vehicle.User.UserName,
                MaintenanceType = x.MaintenanceType,
                Description = x.Description
            }).ToList();

            return View(data);
        }



        [HttpPost]
        public ActionResult AddMaintenance(MaintenanceActivities model, HttpPostedFileBase document)
        {
            if (ModelState.IsValid)
            {

                if (document != null && document.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(document.FileName);
                    var path = Path.Combine(Server.MapPath("~/Documents/"), fileName);
                    document.SaveAs(path);
                    model.DocumentUrl = "/Documents/" + fileName;
                }

                model.MaintenanceDate = DateTime.Now;
                model.CreatedDate = DateTime.Now;
                model.UserId = User.Identity.GetUserId();
                model.ApprovalStatus = (int)ApprovalStatus.Pending;
                _maintenanceService.AddMaintenance(model);

                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Invalid data" });
        }



        [HttpPost]
        public ActionResult ApproveRequest(int vehicleId)
        {
            try
            {
                _maintenanceService.ApproveRequest(vehicleId);
                return Json(new { success = true, message = "Request Approved" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult RejectedRequest(int vehicleId)
        {
            try
            {
                _maintenanceService.RejectRequest(vehicleId);
                return Json(new { success = true, message = "Request Approved" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }



        [HttpPost]
        public ActionResult DeleteRequest(int vehicleId)
        {
            try
            {
                _maintenanceService.DeleteRequest(vehicleId);
                return Json(new { success = true, message = "Request Deleted" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }

}
