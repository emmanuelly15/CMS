using Blazored.LocalStorage;
using CommonModels.Model;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient client, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _client = client;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<AuthenticatedAdminModel> Login(AuthenticationAdminModel adminForAuthentication)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>(key: "grant_type", value: "password"),
                new KeyValuePair<string, string>(key: "Username", adminForAuthentication.email),
                new KeyValuePair<string, string>(key: "Password", adminForAuthentication.password)
            });

            var authResult = await _client.PostAsync("https://localhost:44304/token", data);
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode == false)
            {
                return null;
            }

            var result = JsonSerializer.Deserialize<AuthenticatedAdminModel>(authContent, options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            await _localStorage.SetItemAsync(key: "authToken", result.Access_Token);

            ((AuthStateProvider)_authStateProvider).NotifyAdminAuthentication(result.Access_Token);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "bearer", result.Access_Token);

            return result;
        }

     
    }
}
