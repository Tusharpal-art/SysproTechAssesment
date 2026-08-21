using SysproAssigment.Application.Request.Auth;
using SysproAssigment.Application.Response.Auth;
using SysproAssigment.Domain.Entities;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Interfaces
{
    public interface IAuthServices
    {
        Task<Result<RegisterRespone>> RegisterUserAsync(RegisterRequest registerRequest);
        Task<Result<LoginResponse>> LoginAsync(LoginRequest loginRequest);
        Task<Result<Users>> GetCurrentUser();
    }
}
