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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(300)]
        public string Office_Address { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone_Extension_Number { get; set; }



        [Required]
        [StringLength(20)]
        public string Role { get; set; }

        public virtual Person Person { get; set; }
    }
}
