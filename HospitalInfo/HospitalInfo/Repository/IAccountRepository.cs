using HospitalInfo.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HospitalInfo.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SingUpAsync(SignUpModel signUpModel);
        Task<string> LogInAsync(SignInModel signInModel);
    }
}