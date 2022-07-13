using aysconsultores.dotnet_azure_function.Contracts;
using aysconsultores.dotnet_azure_function.Helpers;
using aysconsultores.dotnet_azure_function.Repositories;
using aysconsultores.dotnet_azure_function.Services;
using aysconsultores.dotnet_azure_function.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration(config =>
    {
        config
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    })
    .ConfigureServices(services =>
    {
        var config = new ConfigurationBuilder()
           .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
           .AddJsonFile("local.settings.json", true)
           .AddEnvironmentVariables()
           .Build();
        // Database connection service
        //var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:DefaultConnection");
        services.AddDbContext<ApiDataContext>(options =>
            options.UseSqlServer(
                config["ConnectionStrings:DefaultConnection"],
                sqlServerOptions => sqlServerOptions.CommandTimeout(600)));

        // JWT Authentication
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://localhost:7071",
                    ValidAudience = "https://localhost:7071",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fjurkbdlhmklqacwqzdxmkkhvqoclyqz"))
                };
            });

        // DI for customized services and repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

    })
    .UseDefaultServiceProvider(options => options.ValidateScopes = false)
    .Build();

host.Run();