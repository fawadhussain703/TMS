using System;
using System.Collections.Generic;
using System.Text;
using Tms.Data.AppContext;

namespace Tms.Service.Vehicle
{
    public interface IVehicleService
    {

        List<Vehicles> GetVehicles(string userId);
    }
}
