using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Taxi.Core.Interfaces;
using Taxi.Core.Interfaces.Admin;
using Taxi.Core.Services;
using Taxi.Core.Services.AdminPanel;
using Taxi.DataAccessLayer.Context;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

#region add service
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAccounting, AccouuntService>();
builder.Services.AddScoped<IAdmin, AdminService>();

#endregion

#region Config DataBase
builder.Services.AddDbContext<DatabaseContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
