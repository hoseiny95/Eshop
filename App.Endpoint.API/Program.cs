using App.Domain.AppServices;
using App.Domain.AppServices.Products;
using App.Domain.AppServices.User;
using App.Domain.Core.Products.Contract.AppServices;
using App.Domain.Core.Products.Contract.Repositories;
using App.Domain.Core.Products.Contract.Services;
using App.Domain.Core.Users.Contract.AppServices;
using App.Domain.Core.Users.Contract.Manager;
using App.Domain.Core.Users.Contract.Repositories;
using App.Domain.Core.Users.Contract.Services;
using App.Domain.Core.Users.Entities;
using App.Domain.Services;
using App.Domain.Services.Products;
using App.Domain.Services.User;
using App.Infra.Data.Repos.Ef;
using App.Infra.Data.Repos.Ef.Products;
using App.Infra.Data.Repos.Ef.User;
using App.Infra.Data.SqlServer.Ef.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using NLog;
using NLog.Web;
using System.Text;
using App.Endpoint.API.MiddleWares;
using Microsoft.Extensions.DependencyInjection;

    var builder = WebApplication.CreateBuilder(args);


    LogManager.Configuration = new NLogLoggingConfiguration(builder.Configuration.GetSection("NLog"));

    var logger = NLogBuilder.ConfigureNLog(LogManager.Configuration).GetCurrentClassLogger();


// Add services to the container.
try
{
    logger.Info("our massage is nlog is not good");
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddInfrastructure();
    builder.Services.AddServices();
    builder.Services.AddAppServices();
    //builder.Logging.AddNLog();
    //builder.Host.UseNLog();
    builder.Services.AddLogging(loggingBuilder =>
    {
        loggingBuilder.ClearProviders();
        loggingBuilder.AddNLog();
        loggingBuilder.AddSeq();
    });


    builder.Services.AddDbContext<Maktab97ShopDbContext>();
    builder.Services.AddSingleton(typeof(NLog.ILogger), logger);


    builder.Services.AddIdentity<ApplicationUser, Role>()
                .AddEntityFrameworkStores<Maktab97ShopDbContext>()
                .AddUserManager<AppUserManager>()
                .AddRoles<Role>()
                .AddDefaultTokenProviders();


    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
         .AddCookie()
         .AddJwtBearer(jwtBearerOptions =>
         {
             jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
             {
                 ValidateActor = false,
                 ValidateAudience = true,
                 ValidateLifetime = true,
                 ValidateIssuerSigningKey = true,
                 ValidIssuer = "ESop",
                 ValidAudience = "hello",
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                     ("salamll08909767855677575ff"))
             };
         });

    builder.Services.AddSwaggerGen(swagger =>
    {
        //This is to generate the Default UI of Swagger Documentation
        swagger.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = " Identity api",
            Description = "ASP.NET Core 7.0 Web API"
        });
        // To Enable authorization using Swagger (JWT)
        swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        });
        swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}

                }
                });

    });


    builder.Services.Configure<IdentityOptions>(options =>
    {
        // Password settings
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 3;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequiredUniqueChars = 0;
        // Lockout settings
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
        options.Lockout.MaxFailedAccessAttempts = 1000;
        options.Lockout.AllowedForNewUsers = true;
        // User settings
        options.User.RequireUniqueEmail = false;
        options.SignIn.RequireConfirmedEmail = false;
    });

    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddControllersWithViews();
    builder.Services.AddTransient<ErrorHandleMiddleWare>();
    //builder.Services.AddExceptionHandler<ErrorHandleMiddleWare>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
    }
    app.UseMiddleware<ErrorHandleMiddleWare>();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();

    logger.Debug("Init main");
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
}
finally
{
    LogManager.Shutdown();
}
