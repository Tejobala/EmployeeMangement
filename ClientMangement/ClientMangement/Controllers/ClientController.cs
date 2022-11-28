using ClientMangement.Models;
using ClientMangement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientMangement.Controllers
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

        //[HttpGet("")]
        //public async Task<IActionResult> GetAll([FromQuery] Paginator filter)
        //{
        //    var clients = await _clientRepository.GetAll(filter);
        //    return Ok(clients);
        //}
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(ClientModel ClientModel, int id)
        {
            await _clientRepository.UpdateClienteAsync(id, ClientModel);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            await _clientRepository.DeleteClientAsync(id);
            return Ok();
        }
    }
}
