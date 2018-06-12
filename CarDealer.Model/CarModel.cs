namespace CarDealer.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarModel")]
    public partial class CarModel
    {
        public CarModel()
        {
            IndividualCars = new Collection<IndividualCar>();
        }

        [Key]
        public int ModelID { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        public int? NumberOfSeats { get; set; }

        public double? EngineSize { get; set; }
        
        public virtual ICollection<IndividualCar> IndividualCars { get; set; }
    }
}
