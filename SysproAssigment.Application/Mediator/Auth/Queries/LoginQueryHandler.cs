using MediatR;
using SysproAssigment.Application.Interfaces;
using SysproAssigment.Application.Request.Auth;
using SysproAssigment.Application.Response.Auth;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Mediator.Auth.Queries
{
    public class LoginQueryHandler(IAuthServices authService) : IRequestHandler<LoginRequest, Result<LoginResponse>>
    {
        public async Task<Result<LoginResponse>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            Result<LoginResponse> result = await authService.LoginAsync(request);
            return result;
        }
    }
}
