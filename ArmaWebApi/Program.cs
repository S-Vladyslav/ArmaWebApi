using DataAccess.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Repositories.Abstraction;
using Repositories.UnitOfWorks;
using Services;
using Services.Abstraction;
using System.Text;
using Microsoft.Extensions.Configuration;
using Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add configuration
var configuration = builder.Configuration;
configuration.AddJsonFile("appsettings.json");

var configurationManager = new CustomConfigurationManager(configuration);
builder.Services.AddSingleton<ICustomConfigurationManager>(configurationManager);

//Add Services and Repositories
#region Services
builder.Services.AddTransient<IArticleToApproveService, ArticleToApproveService>();
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ISessionService, SessionService>();
#endregion

#region Repositories
builder.Services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
//https://damienaicheh.github.io/azure/azure-functions/dotnet/2022/05/10/use-settings-json-azure-function-en.html