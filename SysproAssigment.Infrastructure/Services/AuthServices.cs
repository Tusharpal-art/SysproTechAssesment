using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SysproAssigment.Application.Interfaces;
using SysproAssigment.Application.Request.Auth;
using SysproAssigment.Application.Response.Auth;
using SysproAssigment.Domain.Entities;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SysproAssigment.Infrastructure.Services
{
    public class AuthServices(UserManager<Users> userManager, IMapper mapper, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : IAuthServices
    {
        public async Task<Result<Users>> GetCurrentUser()
        {
            string currentUserId = httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            Guid id = Guid.TryParse(currentUserId, out var userId) ? userId : Guid.Empty;
            if (id == Guid.Empty)
            {
                return Result<Users>.Failure("Error occur while convert string id to guid");
            }
            Users? user = await unitOfWork.GetRepository<Users>().GetByIdAsync(id);
            if (user == null)
            {
                return Result<Users>.Failure("User not found who is authorize");
            }
            return Result<Users>.Successs(user);
        }

        public async Task<Result<LoginResponse>> LoginAsync(LoginRequest loginRequest)
        {
            Users? user = await userManager.FindByEmailAsync(loginRequest.Email);

            if (user == null)
                return Result<LoginResponse>.Failure("Email Was Not Found! Please Enter Correct Email");

            bool checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (!checkPasswordResult)
                return Result<LoginResponse>.Failure("Your Password Is Wrong! Please Enter Correct Password");

            IList<string> roles = await userManager.GetRolesAsync(user);

            string newAccessToken = CreateJwtToken(user, roles);

            LoginResponse loginResponse = new(newAccessToken);

            return Result<LoginResponse>.Successs(loginResponse);
        }

        public async Task<Result<RegisterRespone>> RegisterUserAsync(RegisterRequest registerRequest)
        {
            Users user = mapper.Map<Users>(registerRequest);
            user.UserName = registerRequest.Email;
            IdentityResult identityResult = await userManager.CreateAsync(user, registerRequest.Password);
            if (identityResult.Succeeded)
            {
                identityResult = await userManager.AddToRoleAsync(user, "User");
                RegisterRespone userResponse = new(registerRequest.Name);
                return Result<RegisterRespone>.Successs(userResponse);
            }
            IEnumerable<IdentityError> error = identityResult.Errors;
            StringBuilder errorMessage = new StringBuilder();
            foreach (var er in error)
            {
                errorMessage.Append(er.Description);
            }
            return Result<RegisterRespone>.Failure(errorMessage.ToString());
        }

        public string CreateJwtToken(Users user, IList<string> roles)
        {
            List<Claim> claims =
            [
                new(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new(ClaimTypes.Name , user.Name),
                new(ClaimTypes.Email , user.Email ?? String.Empty),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            ];

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            SymmetricSecurityKey? Key = new(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? string.Empty));
            SigningCredentials credentials = new(Key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
