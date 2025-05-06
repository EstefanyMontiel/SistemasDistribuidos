using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Services;
using PokemonApi.Repositories;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();

builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokemonRepository,PokemonRepository>();

//para que sirven

builder.Services.AddScoped<IHobbyService, HobbyService>();
builder.Services.AddScoped<IHobbyRepository,HobbyRepository>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository,BookRepository>();



builder.Services.AddDbContext<RelationalDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")))); //conexion a la base de datos
var app = builder.Build();

app.UseSoapEndpoint<IPokemonService>("/PokemonService.svc", new SoapEncoderOptions()); //levantar el servicio 
app.UseSoapEndpoint<IHobbyService>("/EstefanyMontielService.svc", new SoapEncoderOptions()); //levantar el servicio 
app.UseSoapEndpoint<IBookService>("/BookService.svc", new SoapEncoderOptions()); //levantar el servicio 

app.Run();
