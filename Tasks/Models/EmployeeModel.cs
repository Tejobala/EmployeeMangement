using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Tasks.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please add Name Property"),Column(TypeName ="nvarchar(30)")]
        public string Name { get; set; }

        [Required(ErrorMessage="Please add Salary"),Column(TypeName ="int")]
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
//public async Task<List<ClientModel>> GetAll()
//{

//    var records = await _context.Client.Select(x => new ClientModel
//    {
//        LicenceId = x.LicenceId,
//        ClientName = x.ClientName,
//        LicenceKeyGUID = x.LicenceKeyGUID,
//        Description = x.Description,
//        LicenceStartDate = x.LicenceStartDate,
//        LicenceEndtDate = x.LicenceEndtDate,
//    }).ToListAsync();
//    return records;
//}
//public async Task<ClientModel> GetByIdAsync(int licenceId)
//{

//    var records = await _context.Client.Where(x => x.LicenceId == licenceId).Select(x => new ClientModel
//    {
//        LicenceId = x.LicenceId,
//        ClientName = x.ClientName,
//        LicenceKeyGUID = x.LicenceKeyGUID,
//        Description = x.Description,
//        LicenceStartDate = x.LicenceStartDate,
//        LicenceEndtDate = x.LicenceEndtDate,
//    }).FirstOrDefaultAsync();
//    return records;
//}
//public async Task<int> AddClientAsync(ClientModel clientModel)
//{

//    var client = new Client()
//    {
//        LicenceId = clientModel.LicenceId,
//        ClientName = clientModel.ClientName,
//        LicenceKeyGUID = clientModel.LicenceKeyGUID,
//        Description = clientModel.Description,
//        LicenceStartDate = DateTime.Now
//    };
//    _context.Client.Add(client);
//    await _context.SaveChangesAsync();
//    return client.LicenceId;
//}


//[Required]
//[Key]
//public int LicenceId { get; set; }

//[Required(ErrorMessage = "Please add LicenceKeyGUID Property"), Column(TypeName = "nvarchar(30)")]
//public string LicenceKeyGUID { get; set; }

//[Required(ErrorMessage = "Please add ClientName Property"), Column(TypeName = "nvarchar(30)")]
//public string ClientName { get; set; }

//[Required(ErrorMessage = "Please add Description Property"), Column(TypeName = "nvarchar(30)")]
//public string Description { get; set; }
//public DateTime LicenceStartDate { get; set; }
//public DateTime? LicenceEndtDate { get; set; }