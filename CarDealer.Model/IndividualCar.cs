namespace CarDealer.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IndividualCar")]
    public partial class IndividualCar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IndividualCar()
        {
            Cars_Sold = new HashSet<Cars_Sold>();
            CarFeatures = new HashSet<CarFeature>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CarID { get; set; }

        [Required]
        [StringLength(50)]
        public string Colour { get; set; }

        [Required]
        [StringLength(50)]
        public string Current_Mileage { get; set; }

        [Required]
        [StringLength(10)]
        public string Date_Imported { get; set; }

        public int Manufacture_Year { get; set; }

        [Required]
        [StringLength(50)]
        public string Transmission { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [StringLength(50)]
        public string Body_Type { get; set; }

        public int Model_ID { get; set; }

        public virtual CarModel CarModel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cars_Sold> Cars_Sold { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarFeature> CarFeatures { get; set; }
    }
}
