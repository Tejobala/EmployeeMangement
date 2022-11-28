using ClientMangement.Data;
using ClientMangement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NLog.Filters;

namespace ClientMangement.Repository
{

    public class ClientRepository : IClientRepository
    {
        private readonly ClientDbContect _context;

        public ClientRepository(ClientDbContect Context)
        {
            _context = Context;
        }

        //public async Task<List<ClientModel>> GetAll(Paginator filter)
        //{
        //    var paginator = new Paginator(filter.PerPage, filter.CurrentPage);
        //    var records = await _context.Client.Select(x => new ClientModel
        //    {
        //        LicenceId = x.LicenceId,
        //        ClientName = x.ClientName,
        //        LicenceKeyGUID = x.LicenceKeyGUID,
        //        Description = x.Description,
        //        LicenceStartDate = x.LicenceStartDate,
        //        LicenceEndtDate = x.LicenceEndtDate,
        //    }).Skip((filter.CurrentPage)-1*Paginator.perpage).Take(Paginator.perpage).ToListAsync();
         
        //    return records;
        //}
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
        public async Task UpdateClienteAsync(int licenceId, ClientModel clientModel)
        {
            var client = await _context.Client.FindAsync(licenceId);
            if (client != null)
            {
                client.ClientName = clientModel.ClientName;
                client.LicenceKeyGUID = clientModel.LicenceKeyGUID;
                client.Description = clientModel.Description;
                client.LicenceEndtDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteClientAsync(int clientId)
        {
            var book = new Client()
            {
                LicenceId = clientId
            };
            _context.Client.Remove(book);
            await _context.SaveChangesAsync();
        }

    }
}

