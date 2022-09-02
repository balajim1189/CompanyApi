using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Company.Entities
{
    [Table("employee")]
    public class Employee : BaseEntity
    {
        [Column("employeename"), Required, StringLength(50)]
        public string EmployeeName { get; set; }

        [Column("age"), Required]
        public int Age { get; set; }

        [Column("salary"), Required]
        public double Salary { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set;}
           [JsonIgnore]
         public virtual Department Department { get; set; }

    }
}