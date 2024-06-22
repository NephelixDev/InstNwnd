using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.DbObjects;
using InstNwnd.Web.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<InstNwndContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("InstNwndContext")));

builder.Services.AddScoped<IRegionDb, RegionDb>();

builder.Services.AddScoped<ITerritoriesDb, TerritoriesDb>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
