using MasterChef.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sale.Application.Interfaces;
using Sale.Application.Services;
using Sale.Domain.Contracts;
using Sale.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(
    s => {
        s.SwaggerDoc("v1", new OpenApiInfo() { Title = "Sale System API", Version = "V1" });
    });

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
}).AddXmlDataContractSerializerFormatters();

var connection = @"Data Source=PERSONAL\SQLEXPRESS;Database=SalesSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False; TrustServerCertificate = False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

builder.Services.AddDbContext<DataContext>
    (o => o.UseSqlServer(connection));

builder.Services.AddTransient<ISaleService, SaleService>();
builder.Services.AddTransient<IInventoryService, InventoryService>();
builder.Services.AddTransient<ISaleRepository, SaleRepository>();
builder.Services.AddTransient<IInventoryRepository, InventoryRepository>();

builder.Services.Configure<RouteOptions>
                (options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sale System API"));

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();