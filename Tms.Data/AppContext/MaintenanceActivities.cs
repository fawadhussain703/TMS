using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tms.Data.AppContext
{
    public partial class MaintenanceActivities
    {
        public int MaintenanceActivityId { get; set; }
        public int VehicleId { get; set; }
        public string UserId { get; set; }
        public string SupervisorId { get; set; }
        public int ApprovalStatus { get; set; }
        public string DocumentUrl { get; set; }
        public string MaintenanceType { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual AspNetUsers Supervisor { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual Vehicles Vehicle { get; set; }
    }
}
