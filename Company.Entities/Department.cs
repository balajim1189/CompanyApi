using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Entities
{
    [Table("department")]
    public class Department : BaseEntity
    {
        
        [Column("departmentname"), Required, StringLength(50)]
        public string DepartmentName { get; set; }

        [Column("description"), Required, StringLength(50)]
        public string Description { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}