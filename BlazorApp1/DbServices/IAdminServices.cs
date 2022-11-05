using CommonModels.Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Services
{
    public interface IAdminService
    {
        public Task<User> LoginAsync(User user);
        public Task<User> RegisterUserAsync(User user);
        public Task<User> GetUserByAccessTokenAsync(string accessToken);
        public Task<User> RefreshTokenAsync(RefreshRequest refreshRequest);
    }
}