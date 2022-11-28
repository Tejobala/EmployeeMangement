using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IClientRepository
    {
        Task<List<ClientModel>> GetAll();
        Task<ClientModel> GetByIdAsync(int licenceId);
        Task<int> AddClientAsync(ClientModel clientModel);
    }
}