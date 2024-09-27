using MShop.Order.Application.Features.CQRS.Handlers.AddressHandlers.Read;
using MShop.Order.Application.Features.CQRS.Handlers.AddressHandlers.Write;
using MShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Read;
using MShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Write;
using MShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers.Read;
using MShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers.Write;
using MShop.Order.Application.Interfaces;
using MShop.Order.Application.ServiceRegistrations;
using MShop.Order.Persistence.Context;
using MShop.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrderContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddApplicatonServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
