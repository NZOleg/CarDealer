namespace CarDealer.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarFeature")]
    public partial class CarFeature
    {
        public CarFeature()
        {
            IndividualCars = new Collection<IndividualCar>();
        }

        [Key]
        public int FeatureID { get; set; }

        [StringLength(50)]
        public string Car_Feature { get; set; }

        [StringLength(256)]
        public string Car_Feature_Description { get; set; }

        public virtual ICollection<IndividualCar> IndividualCars { get; set; }
    }
}
