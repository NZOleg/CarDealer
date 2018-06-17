namespace CarDealer.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            CarSale = new Collection<CarSale>();
        }

        [ForeignKey("Person")]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string LicenceNumber { get; set; }

        public int Age { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime LicenseExpiryDate { get; set; }
        
        public virtual ICollection<CarSale> CarSale { get; set; }

        [Required]
        public virtual Person Person { get; set; }
    }
}
