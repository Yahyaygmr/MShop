using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.Order.Application.Features.CQRS.Commands.OrderingCommands;
using MShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers.Read;
using MShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers.Write;
using MShop.Order.Application.Features.CQRS.Queries.OrderingQueries;

namespace MShop.Order.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly GetOrderingQueryHandler _getOrderingQueryHandler;
        private readonly GetOrderingByIdQueryHandler _getOrderingByIdQueryHandler;
        private readonly CreateOrderingCommandHandler _createOrderingCommandHandler;
        private readonly UpdateOrderingCommandHandler _updateOrderingCommandHandler;
        private readonly RemoveOrderingCommandHandler _removeOrderingCommandHandler;

        public OrderingsController(GetOrderingQueryHandler getOrderingQueryHandler, GetOrderingByIdQueryHandler getOrderingByIdQueryHandler, CreateOrderingCommandHandler createOrderingCommandHandler, UpdateOrderingCommandHandler updateOrderingCommandHandler, RemoveOrderingCommandHandler removeOrderingCommandHandler)
        {
            _getOrderingQueryHandler = getOrderingQueryHandler;
            _getOrderingByIdQueryHandler = getOrderingByIdQueryHandler;
            _createOrderingCommandHandler = createOrderingCommandHandler;
            _updateOrderingCommandHandler = updateOrderingCommandHandler;
            _removeOrderingCommandHandler = removeOrderingCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _getOrderingQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdering(int id)
        {
            var values = await _getOrderingByIdQueryHandler.Handle(new GetOrderingByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _createOrderingCommandHandler.Handle(command);
            return Ok("Sipariş detayı kaydı başarılı.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _updateOrderingCommandHandler.Handle(command);
            return Ok("Sipariş detayı güncellendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _removeOrderingCommandHandler.Handle(new RemoveOrderingCommand(id));
            return Ok("Sipariş detayı silindi.");
        }
    }
}
