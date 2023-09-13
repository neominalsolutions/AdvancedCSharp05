using Microsoft.Extensions.DependencyInjection.Extensions;
using MicrosoftDIWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services ile uygulama �al���rken ihtiyac�m�z olan hizmetlere ait instance lifetime y�netimleri yap�l�yor.


// 3 farkl� s�n�f instance lifetime yakla��m� var
// 1. Transient => Her bir class iste�inde instance al�n�r
// 2. Scoped => Web Request bazl� tek bir instance al�r
// 3. Singleton => Uygulama aya�a kalkt��� an itibari ile down olana kadar tek bir instance ile �al���r
// IoC Registration
// Registration, Resolve => Controller veya service i�erisinde Dependency Injection ile servislerin intance ula�ma i�lemi.
builder.Services.AddScoped<ScopedService>();
builder.Services.AddTransient<TransientService>();
builder.Services.AddSingleton<SingletonService>();

// IService Interface �a��r�l�d���nda bunun i�in a�a��daki s�n�f�n instance uygulama genelinde al.
// IService g�rd��� her yerde SingletonService
// IService referance uygulamada 150 yerde var ve biz bu hizmeti tek bir dosyadan kod de�i�ikli�i yapmadan g�ncellemek istiyoruz.
// uygulama genelinde Dependecy Injetion yaparken interface kullan�rsan�z. Yukar�daki 150 yerdeki kod de�i�tirme maliyeti burada 29.sat�rdaki tek bir dosyaya bakar ve b�ylece uygulam�n�n bak�m maliyeti d��m�� olur.



var serviceBuilder = new ServiceBuilder(builder.Configuration);
var service = serviceBuilder.GetServiceFromConfig();


builder.Services.AddScoped<IService, ScopedService>();


var app = builder.Build(); // web application instance

// Service Registeration yukar�daki kod blogundan �nce yap�lmal�d�r

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
