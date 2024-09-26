using MShop.Order.Application.Features.CQRS.Queries.OrderingQueries;
using MShop.Order.Application.Features.CQRS.Results.OrderingResults;
using MShop.Order.Application.Interfaces;
using MShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers.Read
{
    public class GetOrderingByIdQueryHandler
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);

            return new GetOrderingByIdQueryResult()
            {
                OrderingId = value.OrderingId,
                OrderDate = value.OrderDate,
                TotalPrice = value.TotalPrice,
                UserId = value.UserId,
            };
        }
    }
}
