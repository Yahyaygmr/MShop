using MShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MShop.Order.Application.Interfaces;
using MShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShop.Order.Application.Features.CQRS.Handlers.AddressHandlers.Write
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressCommand command)
        {
            await _repository.CreateAsync(new()
            {
                City = command.City,
                Detail = command.Detail,
                District = command.District,
                UserId = command.UserId
            });
        }
    }
}
