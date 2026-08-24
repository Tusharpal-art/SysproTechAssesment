using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SysproAssigment.Api.ExceptionHandler;
using SysproAssigment.Application.Extention;
using SysproAssigment.Application.Interfaces;
using SysproAssigment.Domain.Entities;
using SysproAssigment.Infrastructure.ApplicationDbContext;
using SysproAssigment.Infrastructure.Repositories;
using SysproAssigment.Infrastructure.Services;
using System.Reflection;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Syspro Assesment", Version = "v1" });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "Bearer",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
builder.Services.AddDbContext<ApplicationContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DellConnectionString")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<ISalesServices,SalesServices>();

builder.Services.AddIdentityCore<Users>()
.AddRoles<IdentityRole<Guid>>()
.AddTokenProvider<DataProtectorTokenProvider<Users>>("SysproAssesment")
.AddEntityFrameworkStores<ApplicationContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? String.Empty))
            });

builder.Services.Configure<IdentityOptions>(o =>
{
    o.Password.RequireDigit = true;
    o.Password.RequireLowercase = true;
    o.Password.RequiredLength = 6;
    o.Password.RequiredUniqueChars = 1;
    o.Password.RequireUppercase = true;
});

builder.Services.AddApplicationServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseExceptionHandler(_ => { });
app.UseAuthorization();

app.MapControllers();

app.Run();
