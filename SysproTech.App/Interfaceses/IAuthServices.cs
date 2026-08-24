
using SysproTech.App.Requestses.Auth;
using SysproTech.App.Res;
using SysproTech.App.Responses;

namespace SysproTech.App.Interfaceses
{
    public interface IAuthServices
    {
        Task<Result<LoginResponse>> LoginAccount(LoginModel loginDto);
        Task<Result<RegisterReponse>> Register(RegistrationModel registerDto);
    }
}
