namespace CarDealer.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IndividualCar")]
    public partial class IndividualCar
    {

        public IndividualCar()
        {
            CarFeatures = new Collection<CarFeature>();

        }

        [Key]
        public int CarID { get; set; }

        [Required]
        [StringLength(50)]
        public string Colour { get; set; }

        [Required]
        public int? Current_Mileage { get; set; }

        [Required]
        public DateTime Date_Imported { get; set; }
        
        public int? Manufacture_Year { get; set; }

        [Required]
        [StringLength(50)]
        public string Transmission { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [StringLength(50)]
        public string Body_Type { get; set; }

        [Required]
        public int AskingPrice { get; set; }


        public virtual CarModel CarModel { get; set; }

        public virtual Cars_Sold Cars_Sold { get; set; }

        public virtual ICollection<CarFeature> CarFeatures { get; set; }
    }
}
