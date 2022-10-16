using CommonModels.Model;
using System.Threading.Tasks;

namespace BlazorApp1.Authentication
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }
}