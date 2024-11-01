namespace Tms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MaintenanceActivity
    {
        public int MaintenanceActivityId { get; set; }

        public int VehicleId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [StringLength(128)]
        public string SupervisorId { get; set; }

        public int ApprovalStatus { get; set; }

        public string DocumentUrl { get; set; }

        public string MaintenanceType { get; set; }

        public DateTime MaintenanceDate { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual AspNetUser AspNetUser1 { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
