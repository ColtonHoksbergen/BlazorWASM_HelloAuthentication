using BlazorWASM_HelloAuthentication.Shared.Models.CustomModels;

namespace BlazorWASM_HelloAuthentication.Client.Authentication
{
    public interface IAuthService
    {
        Task<CurrentUser> CurrentUserInfo();
    }
}