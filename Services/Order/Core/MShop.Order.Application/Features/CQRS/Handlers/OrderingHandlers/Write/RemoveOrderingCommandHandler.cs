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
    public class RemoveOrderingCommandHandler
    {
        private readonly IRepository<Ordering> _repository;

        public RemoveOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task Handler(RemoveOrderingCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
