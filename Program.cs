using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Fodun.Data;
using Fodun.Services;
using Microsoft.AspNetCore.Identity;
using Fodun.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddTransient<EmailService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISedeService, SedeService>();
builder.Services.AddScoped<IReservaService, ReservaService>();
builder.Services.AddScoped<ITarifaService, TarifaService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"),
    new MySqlServerVersion(new Version(8, 0, 20))));

// Configurar Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configurar la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=UsuariosView}/{action=Login}/{id?}");
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
