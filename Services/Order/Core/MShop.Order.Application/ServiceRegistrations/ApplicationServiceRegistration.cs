using Microsoft.Extensions.DependencyInjection;
using MShop.Order.Application.Features.CQRS.Handlers.AddressHandlers.Read;
using MShop.Order.Application.Features.CQRS.Handlers.AddressHandlers.Write;
using MShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Read;
using MShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Write;
using MShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers.Read;
using MShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShop.Order.Application.ServiceRegistrations
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicatonServices(this IServiceCollection services)
        {
            services.AddScoped<GetAddressByIdQueryHandler>();
            services.AddScoped<GetAddressQueryHandler>();
            services.AddScoped<CreateAddressCommandHandler>();
            services.AddScoped<UpdateAddressCommandHandler>();
            services.AddScoped<RemoveAddressCommandHandler>();

            services.AddScoped<GetOrderDetailByIdQueryHandler>();
            services.AddScoped<GetOrderDetailQueryHandler>();
            services.AddScoped<CreateOrderDetailCommandHandler>();
            services.AddScoped<UpdateOrderDetailCommandHandler>();
            services.AddScoped<RemoveOrderDetailCommandHandler>();

            services.AddScoped<GetOrderingByIdQueryHandler>();
            services.AddScoped<GetOrderingQueryHandler>();
            services.AddScoped<CreateOrderingCommandHandler>();
            services.AddScoped<UpdateOrderingCommandHandler>();
            services.AddScoped<RemoveOrderingCommandHandler>();
        }
    }
}
