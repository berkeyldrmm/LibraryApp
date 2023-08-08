using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Context;
using FluentValidation.AspNetCore;
using LibraryApp.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;

var builder = WebApplication.CreateBuilder(args);

// Fluent validation servisi eklenmiþtir.
builder.Services.AddControllersWithViews()
    .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<StudentValidator>());

//Veritabaný burada eklenmiþtir ve konfigürasyonel deðerler configuration sýnýfý aracýlýðýyla appsettings.json dosyasýndan çekilmiþtir.
builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConString"));
});

//Baðýmlýlýklarýn kontrolünü yapan extension servis burada eklenmiþtir.
builder.Services.ConfigureDependencies();

//Loglama iþlemleri için serilog kütüphanesinin entegrasyonu
Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Debug()
    .WriteTo.File("Logging/logs.txt")
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//Olasý hatalý endpoint giriþinde 404 ekranýn karþýlamasý için gerekli middleware'in eklenmesi
app.UseStatusCodePagesWithReExecute("/Error/ErrorPage", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
