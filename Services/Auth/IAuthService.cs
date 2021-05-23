using System.Threading.Tasks;
using CoreAPIAndEfCore.Common;
using CoreAPIAndEfCore.Dtos;
namespace CoreAPIAndEfCore.Services
{
    public interface IAuthService : IScopedService
    {
        Task<int> Register(UserCreateDto user);
        Task<string> Login(UserLoginDto user);
        Task<bool> UserExists(string userNmae);
    }
}