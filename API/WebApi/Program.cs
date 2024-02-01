using ExtremeClassified.Core;
using ExtremeClassified.WebApi.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ExtremeClassified.WebApi.Services;
using ExtremeClassified.WebApi.Utils;
using Microsoft.AspNetCore.Identity;
using ExtremeClassified.DataAccess;
using Microsoft.EntityFrameworkCore;
using ExtremeClassified.WebApi.Functions;
using ExtremeClassified.WebApi.Functions.Identity;

const string ConName = "LocalConnection";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILoggerProvider, PortalLoggerProvider>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddCors(c =>
{
    c.AddPolicy("_myAllowAllOrigins", opt =>
    {
        opt.AllowAnyOrigin();
        opt.AllowAnyMethod();
        opt.AllowAnyHeader();
    });
});

//Below Code is only for migration
builder.Services.AddDbContext<PortalDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString(ConName));
});

Action<ApplicationSettings> appSettings = (x =>
{
    x.ConnectionString = builder.Configuration.GetConnectionString(ConName);
});
builder.Services.Configure<ApplicationSettings>(appSettings);


Action<PortalLoggerOptions> loggerSettings = (x =>
{
    x.FilePath = builder.Configuration.GetSection("Logging").GetSection("PortalLogger").GetSection("Options")["FilePath"];
    x.FolderPath = builder.Configuration.GetSection("Logging").GetSection("PortalLogger").GetSection("Options")["FolderPath"];
});
builder.Services.Configure<PortalLoggerOptions>(loggerSettings);

//Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
        };
    });

builder.Services.AddSingleton<AuthenticationManager>();
builder.Services.AddSingleton<ActiveDirectoryAuthentication>();


#region Functions
builder.Services.AddSingleton<UserFunctions>();
builder.Services.AddSingleton<GroupFunctions>();
#endregion

// Password Hashing configuration
builder.Services.Configure<PasswordHasherOptions>(o =>
{
    o.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
    o.IterationCount = 1;
});
builder.Services.AddSingleton<AvPasswordHasher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();
app.UseCors("_myAllowAllOrigins");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseStaticFiles();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
