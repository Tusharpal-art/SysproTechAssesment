using MediatR;
using SysproAssigment.Application.Interfaces;
using SysproAssigment.Application.Request.Auth;
using SysproAssigment.Application.Response.Auth;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Mediator.Auth.Command
{
    public class RegisterCommandHandler(IAuthServices authService) : IRequestHandler<RegisterRequest, Result<RegisterRespone>>
    {
        public async Task<Result<RegisterRespone>> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            Result<RegisterRespone> result = await authService.RegisterUserAsync(request);
            return result;
        }
    }
}
