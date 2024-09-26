using MShop.Order.Application.Features.CQRS.Results.AddressResults;
using MShop.Order.Application.Interfaces;
using MShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShop.Order.Application.Features.CQRS.Handlers.AddressHandlers.Read
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetAddressQueryResult
            {
                AdressId = x.AdressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId,

            }).ToList();
        }
    }
}
