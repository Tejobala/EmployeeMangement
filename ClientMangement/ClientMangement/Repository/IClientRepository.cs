using ClientMangement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientMangement.Repository
{
    public interface IClientRepository
    {
        //Task<List<ClientModel>> GetAll(Paginator filter);
        Task<List<ClientModel>> GetAll();
        Task<ClientModel> GetByIdAsync(int licenceId);
        Task<int> AddClientAsync(ClientModel clientModel);
        Task UpdateClienteAsync(int licenceId, ClientModel clientModel);
        Task DeleteClientAsync(int clientId);
    }
}