namespace CarDealer.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [ForeignKey("Person")]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string OfficeAddress { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneExtensionNumber { get; set; }



        [Required]
        [StringLength(20)]
        public string Role { get; set; }
        
        [Required]
        public virtual Person Person { get; set; }
    }
}
