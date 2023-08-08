using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Context;
using FluentValidation.AspNetCore;
using LibraryApp.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;

var builder = WebApplication.CreateBuilder(args);

// Fluent validation servisi eklenmi�tir.
builder.Services.AddControllersWithViews()
    .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<StudentValidator>());

//Veritaban� burada eklenmi�tir ve konfig�rasyonel de�erler configuration s�n�f� arac�l���yla appsettings.json dosyas�ndan �ekilmi�tir.
builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConString"));
});

//Ba��ml�l�klar�n kontrol�n� yapan extension servis burada eklenmi�tir.
builder.Services.ConfigureDependencies();

//Loglama i�lemleri i�in serilog k�t�phanesinin entegrasyonu
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

//Olas� hatal� endpoint giri�inde 404 ekran�n kar��lamas� i�in gerekli middleware'in eklenmesi
app.UseStatusCodePagesWithReExecute("/Error/ErrorPage", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
