using System;
using System.Collections.Generic;
using System.Text;
using Tms.Data.AppContext;

namespace Tms.Models
{
    public class VehicleViewModel
    {
        public VehicleViewModel()
        {
            
        }
        public int VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string UserId { get; set; }
        public virtual AspNetUsers User { get; set; }
        

    }
}
