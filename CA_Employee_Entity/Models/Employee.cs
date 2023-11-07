using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Employee_Entity.Models
{
    public class Employee
    {
        [Key]
        public int MemberId { get; set; }

        public string? Name { get; set; }

        public double? Salary { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; } // Foreign Key

        public Department? Department { get; set; } //iska column nahi banega

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", Name, Salary, DepartmentId);
        }
    }
}
