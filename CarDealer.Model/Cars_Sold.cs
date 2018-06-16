namespace CarDealer.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cars_Sold
    {
        [Key]
        public int Car_Sold_ID { get; set; }

        [Required]
        public int Sale_Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_Sold { get; set; }

        public virtual Customer Customer { get; set; }
        [Required]
        public virtual IndividualCar IndividualCar { get; set; }
    }
}
