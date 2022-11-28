using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalInfo.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Please Enter your FirstName"), Column(TypeName = "nvarchar(30)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter your LastName"), Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please Enter your Email"), Column(TypeName = "nvarchar(30)")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter your Password"), Column(TypeName = "nvarchar(30)")]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter your ConfirmPassword"), Column(TypeName = "nvarchar(30)")]
        public string ConfirmPassword { get; set; }
    }
}
