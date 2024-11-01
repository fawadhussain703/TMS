using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tms.Models
{
    public class MaintenanceViewModel
    {
        public  MaintenanceViewModel()
        {
        }


        public int MaintenanceActivityId { get; set; }

        public int VehicleId { get; set; }
        public string VehicleNumber { get; set; }

        public string VehicleMake { get; set; }

        public string VehicleModel { get; set; }

        public string VehicleDescription { get; set; }

        public string CreatedBy { get; set; }
        public int VehicleYear { get; set; }
        public string DocumentURL { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [StringLength(128)]
        public string SupervisorId { get; set; }

        public string ApprovalStatus { get; set; }

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