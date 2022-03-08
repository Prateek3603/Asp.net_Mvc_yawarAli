using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }
        public int Bonus { get; set; }
        public int DeptId { get; set; }
        public bool status { get; set; }
    }

    public class EmpdeptModel
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string DepartName { get; set; }
        public int EmpSalary { get; set; }
        
    }
}