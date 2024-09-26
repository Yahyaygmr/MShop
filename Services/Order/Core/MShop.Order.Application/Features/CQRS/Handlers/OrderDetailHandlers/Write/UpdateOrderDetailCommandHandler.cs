using MShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MShop.Order.Application.Interfaces;
using MShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Write
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.OrderDetailId);

            value.OrderingId = command.OrderingId;
            value.ProductPrice = command.ProductPrice;
            value.ProductName = command.ProductName;
            value.ProductId = command.ProductId;
            value.ProductTotalPrice = command.ProductTotalPrice;
            value.ProductAmount = command.ProductAmount;
            
            await _repository.UpdateAsync(value);
        }
    }
}
