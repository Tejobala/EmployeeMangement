using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Models
{
    public class ClientModel
    {
        [Required]
        [Key]
        public int LicenceId { get; set; }

        [Required(ErrorMessage = "Please add LicenceKeyGUID Property"), Column(TypeName = "nvarchar(30)")]
        public string LicenceKeyGUID { get; set; }

        [Required(ErrorMessage = "Please add ClientName Property"), Column(TypeName = "nvarchar(30)")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Please add Description Property"), Column(TypeName = "nvarchar(30)")]
        public string Description { get; set; }
        public DateTime LicenceStartDate { get; set; }
        public DateTime? LicenceEndtDate { get; set; }
    }
}
