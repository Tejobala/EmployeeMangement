using HospitalInfo.Models;
using HospitalInfo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;

        public HospitalController(IHospitalRepository hospitalRepository)
        {
           _hospitalRepository = hospitalRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var hospital = await _hospitalRepository.GetAll();
            return Ok(hospital);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hospital = await _hospitalRepository.GetByIdAsync(id);
            return Ok(hospital);
        }

        [HttpPost("")]
        public async Task<IActionResult> GetAddHospitalAsync([FromBody] HospitalModel HospitalModel)
        {
            var id = await _hospitalRepository.AddHospitalAsync(HospitalModel);
            return CreatedAtAction(nameof(GetById), new { id = id, Controller = "books" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(HospitalModel hospitalModel, int id)
        {
            await _hospitalRepository.UpdateHospitalAsync(id, hospitalModel);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            await _hospitalRepository.DeleteHospitalAsync(id);
            return Ok();
        }
    }
}
