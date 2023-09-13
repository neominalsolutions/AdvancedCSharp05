using Microsoft.Extensions.DependencyInjection.Extensions;
using MicrosoftDIWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services ile uygulama çalýþýrken ihtiyacýmýz olan hizmetlere ait instance lifetime yönetimleri yapýlýyor.


// 3 farklý sýnýf instance lifetime yaklaþýmý var
// 1. Transient => Her bir class isteðinde instance alýnýr
// 2. Scoped => Web Request bazlý tek bir instance alýr
// 3. Singleton => Uygulama ayaða kalktýðý an itibari ile down olana kadar tek bir instance ile çalýþýr
// IoC Registration
// Registration, Resolve => Controller veya service içerisinde Dependency Injection ile servislerin intance ulaþma iþlemi.
builder.Services.AddScoped<ScopedService>();
builder.Services.AddTransient<TransientService>();
builder.Services.AddSingleton<SingletonService>();

// IService Interface çaðýrýlýdýðýnda bunun için aþaðýdaki sýnýfýn instance uygulama genelinde al.
// IService gördüðü her yerde SingletonService
// IService referance uygulamada 150 yerde var ve biz bu hizmeti tek bir dosyadan kod deðiþikliði yapmadan güncellemek istiyoruz.
// uygulama genelinde Dependecy Injetion yaparken interface kullanýrsanýz. Yukarýdaki 150 yerdeki kod deðiþtirme maliyeti burada 29.satýrdaki tek bir dosyaya bakar ve böylece uygulamýnýn bakým maliyeti düþmüþ olur.



var serviceBuilder = new ServiceBuilder(builder.Configuration);
var service = serviceBuilder.GetServiceFromConfig();


builder.Services.AddScoped<IService, ScopedService>();


var app = builder.Build(); // web application instance

// Service Registeration yukarýdaki kod blogundan önce yapýlmalýdýr

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
