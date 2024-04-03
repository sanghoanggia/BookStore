using BookStoreCore.Models;
using BookStoreCore.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("QlbookstoreContext");
builder.Services.AddDbContext<QlbookstoreContext>(X => X.UseSqlServer(connectionString));

builder.Services.AddScoped<IChuDeRepository, ChuDeRespository>();

builder.Services.AddScoped<INhaXuatBanRepository, NhaXuatBanRespository>();

builder.Services.AddSession();

// phần này thêm để sử dụng login
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//theem
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
