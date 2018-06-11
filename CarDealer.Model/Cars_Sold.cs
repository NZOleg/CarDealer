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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Car_Sold_ID { get; set; }

        public int Car_For_Sale_Id { get; set; }

        public int Customer_Id { get; set; }

        [Column(TypeName = "money")]
        public decimal Sale_Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_Sold { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual IndividualCar IndividualCar { get; set; }
    }
}
