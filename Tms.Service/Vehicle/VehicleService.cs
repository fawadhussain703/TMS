using System;
using System.Collections.Generic;
using System.Text;
using Tms.Service.Common;
using Tms.Data.AppContext;
using System.Linq;  

namespace Tms.Service.Vehicle
{
    public class VehicleService : IVehicleService 
    {
        BaseService bs = new BaseService();

        public List<Vehicles> GetVehicles(string userId)
        {
            var list = bs.Entity.Vehicles.Where(x => x.UserId == userId).ToList();

            return list;
        }

    }
}
