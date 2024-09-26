using MShop.Order.Application.Features.CQRS.Commands.OrderingCommands;
using MShop.Order.Application.Interfaces;
using MShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers.Write
{
    public class UpdateOrderingCommandHandler
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderingCommand command)
        {
            var value = await _repository.GetByIdAsync(command.OrderingId);

            value.OrderDate = command.OrderDate;
            value.TotalPrice = command.TotalPrice;
            value.UserId = command.UserId;
            
            await _repository.UpdateAsync(value);
        }
    }
}
