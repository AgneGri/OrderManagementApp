using DataAccess.Entities;
using DataAccess.Repositories;
using OrderApp.Models.OrdersLines.DTO;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.OrdersLines;

namespace OrderApp.Services.OrdersLines.Services
{
	public class DeleteOrderLineService : IService<DeleteOrderLineParameter, OrderLineDto>
	{
		private readonly IRepository<OrderLine> _orderLineRepository;

		public DeleteOrderLineService(IRepository<OrderLine> orderLineRepository)
		{
			_orderLineRepository = orderLineRepository;
		}

		public async Task<Result<OrderLineDto>> CallAsync(DeleteOrderLineParameter parameter)
		{
			var result = await _orderLineRepository.DeleteAsync(parameter.Id);

			if (result)
			{
				return new Result<OrderLineDto>(200, new OrderLineDto());
			}

			return new Result<OrderLineDto>(404, null);
		}
	}
}