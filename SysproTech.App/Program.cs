using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SysproTech.App;
using SysproTech.App.AuthenticationState;
using SysproTech.App.Interfaceses;
using SysproTech.App.Serviceses;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7152/api/") });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IApiServices, ApiServices>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ISalesServices, SalesServices>();
builder.Services.AddTransient<FluentValidation.IValidator<SysproTech.App.Requestses.Auth.LoginModel>, SysproTech.App.Validations.Auth.LoginModelValidator>();
builder.Services.AddTransient<FluentValidation.IValidator<SysproTech.App.Requestses.Auth.RegistrationModel>, SysproTech.App.Validations.Auth.RegistrationModelValidator>();
builder.Services.AddTransient<FluentValidation.IValidator<SysproTech.App.Requestses.Product.AddProductModel>, SysproTech.App.Validations.Product.AddProductModelValidator>();
builder.Services.AddTransient<FluentValidation.IValidator<SysproTech.App.Requestses.UpdateProductRequest>, SysproTech.App.Validations.Product.UpdateProductRequestValidator>();

await builder.Build().RunAsync();





