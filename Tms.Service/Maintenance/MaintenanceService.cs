using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tms.Data.AppContext;
using Tms.Service.Common;

namespace Tms.Service.Maintenance
{
    public class MaintenanceService : BaseService
    {


        public List<MaintenanceActivities> GetMaintenanceList(string userId)
        {
            var list = Entity.MaintenanceActivities.Where(x => x.UserId == userId).ToList();

            return list;
        }


    }
}
