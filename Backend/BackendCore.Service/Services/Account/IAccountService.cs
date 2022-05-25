using System.Threading.Tasks;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Login;

namespace BackendCore.Service.Services.Identity.Account
{
    public interface IAccountService
    {
        Task<IFinalResult> Login(LoginParameters parameters);
    }
}