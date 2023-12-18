using AutoMapper;
using CoreWebhook.Core;
using CoreWebhook.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Logging.Log4Net.AspNetCore;
using System.Reflection;
using CoreWebhook.WebApi.GenWebHook;
using CoreWebhook.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x =>
{
    x.UseOracle(connectionString);
});

// Add services to the container.

builder.Services.AddMvcCore().AddCoreWebHooks();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddLog4Net("log4net.config");


var app = builder.Build();

// Configure Web API for self-host. 
//HttpConfiguration config = new HttpConfiguration();
//config.InitializeReceiveGenericJsonWebHooks();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
