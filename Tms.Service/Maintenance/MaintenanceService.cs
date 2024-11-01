using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tms.Core;
using Tms.Data.AppContext;
using Tms.Service.Common;

namespace Tms.Service.Maintenance
{
    public class MaintenanceService : BaseService
    {


        public List<MaintenanceActivities> GetMaintenanceList(string userId)
        {
            var list = Entity.MaintenanceActivities
                .Include(x=>x.Vehicle)
                .ThenInclude(x=>x.User).Where(x => x.UserId == userId).ToList();

            return list;
        }
        public List<MaintenanceActivities> GetAllMaintenance()
        {
            var list = Entity.MaintenanceActivities
                .Include(x => x.Vehicle)
                .ThenInclude(x => x.User).ToList();


            return list;
        }
        public void AddMaintenance(MaintenanceActivities maintenance)
        {
            Entity.MaintenanceActivities.Add(maintenance);
            Entity.SaveChanges();
        }
        public void ApproveRequest(int vehicleId)
        {
            var maintenanceRequest = Entity.MaintenanceActivities
                .FirstOrDefault(m => m.VehicleId == vehicleId);

            if (maintenanceRequest == null)
                throw new Exception("Maintenance request not found");

            maintenanceRequest.ApprovalStatus = (int)ApprovalStatus.Approved;
            maintenanceRequest.ModifiedDate = DateTime.Now;

            Entity.SaveChanges();
        }

        public void RejectRequest(int vehicleId)
        {
            var maintenanceRequest = Entity.MaintenanceActivities
                .FirstOrDefault(m => m.VehicleId == vehicleId);

            if (maintenanceRequest == null)
                throw new Exception("Maintenance request not found");

            maintenanceRequest.ApprovalStatus = (int)ApprovalStatus.Rejected;
            maintenanceRequest.ModifiedDate = DateTime.Now;

            Entity.SaveChanges();
        }


        public void DeleteRequest(int vehicleId)
        {
            var maintenanceRequest = Entity.MaintenanceActivities
                .FirstOrDefault(m => m.VehicleId == vehicleId);

            if (maintenanceRequest == null)
                throw new Exception("Maintenance request not found");

            Entity.MaintenanceActivities.Remove(maintenanceRequest);
            Entity.SaveChanges();
        }

    }
}
