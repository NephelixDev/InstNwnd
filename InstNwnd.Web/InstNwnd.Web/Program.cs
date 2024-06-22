using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.DbObjects;
using InstNwnd.Web.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<InstNwndContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InstNwndContext")));

builder.Services.AddScoped<IEmployeesDb, EmployeesDb>(); // Registra tu servicio aquí
builder.Services.AddScoped<IOrdersDb, OrdersDb>(); // Registra tu servicio aquí

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
