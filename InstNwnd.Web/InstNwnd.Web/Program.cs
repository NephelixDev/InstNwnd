using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.DbObjects;
using InstNwnd.Web.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<InstNwndContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InstNwndContext")));

builder.Services.AddScoped<IShippersDb, ShippersDb>();
builder.Services.AddScoped<ISuppliersDb, SuppliersDb>(); // Asegúrate de que esto esté registrado
builder.Services.AddScoped<IProductDb, ProductsDb>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
