using Data;
using Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;

namespace Repository
{
    public class ClientRepository: IClientRepository
    {
        private readonly ClientDbContext _context;

        public ClientRepository(ClientDbContext Context)
        {
          _context = Context;
        }

        public async Task<List<ClientModel>> GetAll()
        {

            var records = await _context.Client.Select(x => new ClientModel
            {
                LicenceId = x.LicenceId,
                ClientName = x.ClientName,
                LicenceKeyGUID = x.LicenceKeyGUID,
                Description = x.Description,
                LicenceStartDate = x.LicenceStartDate,
                LicenceEndtDate = x.LicenceEndtDate,
            }).ToListAsync();
            return records;
        }
        public async Task<ClientModel> GetByIdAsync(int licenceId)
        {

            var records = await _context.Client.Where(x => x.LicenceId == licenceId).Select(x => new ClientModel
            {
                LicenceId = x.LicenceId,
                ClientName = x.ClientName,
                LicenceKeyGUID = x.LicenceKeyGUID,
                Description = x.Description,
                LicenceStartDate = x.LicenceStartDate,
                LicenceEndtDate = x.LicenceEndtDate,
            }).FirstOrDefaultAsync();
            return records;
        }
        public async Task<int> AddClientAsync(ClientModel clientModel)
        {

            var client = new Client()
            {
                LicenceId = clientModel.LicenceId,
                ClientName = clientModel.ClientName,
                LicenceKeyGUID = clientModel.LicenceKeyGUID,
                Description = clientModel.Description,
                LicenceStartDate = DateTime.Now
            };
            _context.Client.Add(client);
            await _context.SaveChangesAsync();
            return client.LicenceId;
        }
    }
}
