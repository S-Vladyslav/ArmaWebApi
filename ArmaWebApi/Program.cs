using DataAccess.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Repositories.Abstraction;
using Repositories.UnitOfWorks;
using Services;
using Services.Abstraction;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7228",//Configuration["Jwt:Issuer"],
        ValidAudience = "https://localhost:7228",//Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asda"))//Configuration["Jwt:Key"]))
    };
});

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