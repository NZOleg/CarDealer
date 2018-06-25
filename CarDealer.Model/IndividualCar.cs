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
            CarSale = new Collection<CarSale>();

        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Colour { get; set; }

        [Required]
        public int CurrentMileage { get; set; }

        [Required]
        public DateTime DateImported { get; set; }

        [Required]
        public int ManufactureYear { get; set; }

        [Required]
        [StringLength(50)]
        public string Transmission { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [StringLength(50)]
        public string BodyType { get; set; }

        [Required]
        public int AskingPrice { get; set; }

        public string ImageUri { get; set; }

        [Required]
        public virtual CarModel CarModel { get; set; }

        //for part B to be able to sell car a few times
        public virtual ICollection<CarSale> CarSale { get; set; }

        public virtual ICollection<CarFeature> CarFeatures { get; set; }
    }
}
