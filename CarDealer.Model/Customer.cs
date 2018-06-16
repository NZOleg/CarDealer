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
            Cars_Sold = new Collection<Cars_Sold>();
        }

        [ForeignKey("Person")]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(30)]
        public string Licence_Number { get; set; }

        public int Age { get; set; }

        [Column(TypeName = "date")]
        public DateTime License_Expiry_Date { get; set; }
        
        public virtual ICollection<Cars_Sold> Cars_Sold { get; set; }

        public virtual Person Person { get; set; }
    }
}
