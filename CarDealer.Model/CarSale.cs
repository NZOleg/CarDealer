namespace CarDealer.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("CarSale")]
    public partial class CarSale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SalePrice { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
        [Required]
        public virtual IndividualCar IndividualCar { get; set; }
    }
}
