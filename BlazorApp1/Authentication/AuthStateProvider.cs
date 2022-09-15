using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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
    public class AuthStateProvider : AuthenticationStateProvider
    {

        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationState _anonymous;

        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _anonymous = new AuthenticationState(user: new ClaimsPrincipal(identity: new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>(key: "authToken");

            if (string.IsNullOrWhiteSpace(token))
            {
                return _anonymous;
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "bearer", token);

            return new AuthenticationState(user: new ClaimsPrincipal(identity: new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), authenticationType: "jwtAuthType")));


        }

        public void NotifyAdminAuthentication(string token)
        {
            var authenticatedAdmin = new ClaimsPrincipal(
                identity: new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token),
                authenticationType: "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedAdmin));
            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyAdminLogout()
        {
            var authState = Task.FromResult(_anonymous);
            NotifyAuthenticationStateChanged(authState);

        }

    }
}
