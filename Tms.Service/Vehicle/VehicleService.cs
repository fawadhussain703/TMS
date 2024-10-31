using System;
using System.Collections.Generic;
using System.Text;
using Tms.Service.Common;
using Tms.Data.AppContext;
using System.Linq;  

namespace Tms.Service.Vehicle
{
    public class VehicleService : BaseService
    {
       
        public List<Vehicles> GetVehicles(string userId)
        {
            var list = Entity.Vehicles.Where(x => x.UserId == userId).ToList();

            return list;
        }


        public string SaveVehicles(Vehicles vehicle)
        {

            try
            {
                Entity.Vehicles.Add(vehicle);
                Entity.SaveChanges();
                return "Vehicle saved successfully!";
            }
            catch (Exception ex)
            {
               
                return $"Error saving vehicle: {ex.Message}";
            }


        }

    }
}
