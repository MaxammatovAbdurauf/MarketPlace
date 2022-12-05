using MarketPlays.Database;
using MarketPlays.Entities;
using MarketPlays.Middlewares;
using MarketPlays.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<OrganisationService>();
builder.Services.AddSingleton<P>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(options =>
    {
        options.AllowAnyHeader().AllowAnyOrigin().AllowAnyOrigin();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgres"));
});

builder.Services.AddIdentity<AppUser,IdentityRole<Guid>>(options =>
{
    options.Password.RequiredUniqueChars    = 1;
    options.Password.RequiredLength         = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit           = false;
    options.Password.RequireUppercase       = false;
    options.Password.RequireLowercase       = false;
})
                .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors();
app.UseExceptionHandlerMiddleware();
app.UseRequestLocalization(options =>
{
    options.DefaultRequestCulture   = new RequestCulture ("eng-US");
    options.SupportedUICultures     = new List <CultureInfo> { new CultureInfo ("eng-US") };
    options.SupportedCultures       = new List <CultureInfo> { new CultureInfo ("eng-US") };
    options.RequestCultureProviders = new List <IRequestCultureProvider>();
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();