namespace Tms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            MaintenanceActivities = new HashSet<MaintenanceActivity>();
        }

        public int VehicleId { get; set; }
        [Required(ErrorMessage = "Vehicle number is required.")]
        public string VehicleNumber { get; set; }
        [Required(ErrorMessage = "Make is required.")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Year is required.")]
        [Range(1886, int.MaxValue, ErrorMessage = "Please enter a valid year.")]
        public int Year { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceActivity> MaintenanceActivities { get; set; }
    }
}
