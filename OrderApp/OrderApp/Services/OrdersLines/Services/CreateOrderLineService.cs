using DataAccess.Entities;
using DataAccess.Repositories;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.OrdersLines;
using OrderApp.Models.OrdersLines.DTO;
using OrderApp.Services.OrdersLines.Converters;

namespace OrderApp.Services.OrdersLines.Services
{
	public class CreateOrderLineService : IService<CreateOrderLineParameter, OrderLineDto>
	{
		private readonly IRepository<OrderLine> _orderLineRepository;
		private readonly OrderLineConverter _orderLineConverter;
		private readonly OrderLineDtoConverter _orderLineDtoConverter;

		public CreateOrderLineService(
			IRepository<OrderLine> orderLineRepository,
			OrderLineConverter orderLineConverter,
			OrderLineDtoConverter orderLineDtoConverter)
		{
			_orderLineRepository = orderLineRepository;
			_orderLineConverter = orderLineConverter;
			_orderLineDtoConverter = orderLineDtoConverter;
		}

		public async Task<Result<OrderLineDto>> CallAsync(CreateOrderLineParameter parameter)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			var orderLineEntity = await _orderLineConverter.Create(parameter.OrderLine);
			var createdOrderLine = await _orderLineRepository.CreateAsync(orderLineEntity);
			var orderLineDto = _orderLineDtoConverter.Convert(createdOrderLine);

			return new Result<OrderLineDto>(200, orderLineDto);
		}
	}
}