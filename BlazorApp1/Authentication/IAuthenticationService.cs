using CommonModels.Model;
using System.Threading.Tasks;

namespace BlazorApp1.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticatedAdminModel> Login(AuthenticationAdminModel adminForAuthentication);
        Task<AuthenticatedAdminModel> Logout();
    }
}