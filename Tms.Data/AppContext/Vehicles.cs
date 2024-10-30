using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tms.Data.AppContext
{
    public partial class Vehicles
    {
        public Vehicles()
        {
            MaintenanceActivities = new HashSet<MaintenanceActivities>();
        }

        public int VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<MaintenanceActivities> MaintenanceActivities { get; set; }
    }
}
