
using SysproTech.App.Interfaceses;
using SysproTech.App.Requestses.Auth;
using SysproTech.App.Res;
using SysproTech.App.Responses;

namespace SysproTech.App.Serviceses
{
    public class AuthServices(IApiServices apiService) : IAuthServices
    {
        public async Task<Result<LoginResponse>> LoginAccount(LoginModel loginDto)
        {
            Result<LoginResponse> result = await apiService.PostAsync<LoginResponse>("Auth/Login", loginDto);
            return result;
        }
        public async Task<Result<RegisterReponse>> Register(RegistrationModel registerDto)
        {
            Result<RegisterReponse> result = await apiService.PostAsync<RegisterReponse>("Auth/Register", registerDto);
            return result;
        }
      
    }
}
