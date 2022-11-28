using ClientMangement.Models;
using ClientMangement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ClientMangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]SignUpModel signUpModel)
        { 
            var result = await _accountRepository.SingUpAsync(signUpModel);
            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
        {
            var result = await _accountRepository.LogInAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
