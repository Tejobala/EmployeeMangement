using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMangement.EmployeeData
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please add Name Property"), Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please add Salary"), Column(TypeName = "int")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Please add Location Property"), Column(TypeName = "nvarchar(25)")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please add Department Property"), Column(TypeName = "nvarchar(25)")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Please add Qualification Property"), Column(TypeName = "nvarchar(25)")]
        public string Qualification { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
