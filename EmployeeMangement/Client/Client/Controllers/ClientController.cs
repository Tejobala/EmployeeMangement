using Models;
using Client.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientRepository.GetAll();
            return Ok(clients);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var clients = await _clientRepository.GetByIdAsync(id);
            return Ok(clients);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewClient([FromBody] ClientModel ClientModel)
        {
            var id = await _clientRepository.AddClientAsync(ClientModel);
            return CreatedAtAction(nameof(GetById), new { id = id, Controller = "books" }, id);
        }
    }
}
