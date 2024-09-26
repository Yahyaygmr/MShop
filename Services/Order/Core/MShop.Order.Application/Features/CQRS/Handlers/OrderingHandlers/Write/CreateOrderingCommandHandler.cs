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
    public class CreateOrderingCommandHandler
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOrderingCommand command)
        {
            await _repository.CreateAsync(new()
            {
                OrderDate = command.OrderDate,
                TotalPrice = command.TotalPrice,
                UserId = command.UserId,
            });
        }
    }
}
