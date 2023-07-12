using BlazorWASM_HelloAuthentication.Shared.Models.CustomModels;
using System.Net.Http.Json;

namespace BlazorWASM_HelloAuthentication.Client.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CurrentUser> CurrentUserInfo()
        {
            var result = await _httpClient.GetFromJsonAsync<CurrentUser>("login");
            return result;
        }
    }
}
