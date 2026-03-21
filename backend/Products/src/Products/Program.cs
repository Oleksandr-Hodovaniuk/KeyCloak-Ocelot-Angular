using DotNetEnv;
using Microsoft.AspNetCore.Hosting.Server;
using Products;
using Products.Application;
using Products.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

Env.Load("../../.env");

// Add services to the container.

builder.Services
    .AddApiServices()
    .AddApplicationServices()
    .AddInfrastructureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();