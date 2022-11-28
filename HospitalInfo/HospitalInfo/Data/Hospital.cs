using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalInfo.Data
{
    public class Hospital
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please add LicenceKeyGUID Property"), Column(TypeName = "nvarchar(30)")]
        public string HospitalName { get; set; }


        [Required(ErrorMessage = "Please add Description Property"), Column(TypeName = "nvarchar(30)")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please add Address Property"), Column(TypeName = "nvarchar(30)")]
        public string Address { get; set; }

        [Required]
        public DateTime DateOfRegistration { get; set; }
    }
}
