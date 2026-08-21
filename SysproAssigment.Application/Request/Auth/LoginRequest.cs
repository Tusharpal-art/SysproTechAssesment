using MediatR;
using SysproAssigment.Application.Response.Auth;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SysproAssigment.Application.Request.Auth
{
    public class LoginRequest : IRequest<Result<LoginResponse>>
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$", ErrorMessage = "Please Enter Valid Email")]
        public required string Email { get; set; }
        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{6,20}$", ErrorMessage = "Password must be 6-20 characters with at least one uppercase, one lowercase, one number, and one special character")]
        public required string Password { get; set; }
    }
}
