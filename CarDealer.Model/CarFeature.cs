namespace CarDealer.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarFeature")]
    public partial class CarFeature
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarFeature()
        {
            IndividualCars = new HashSet<IndividualCar>();
        }

        [Key]
        public int FeatureID { get; set; }

        [StringLength(50)]
        public string Car_Feature { get; set; }

        [StringLength(256)]
        public string Car_Feature_Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IndividualCar> IndividualCars { get; set; }
    }
}
