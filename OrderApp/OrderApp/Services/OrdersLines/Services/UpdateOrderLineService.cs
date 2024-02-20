using DataAccess.Entities;
using DataAccess.Repositories;
using OrderApp.Models.OrdersLines.DTO;
using OrderApp.Services.OrdersLines.Converters;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.OrdersLines;

namespace OrderApp.Services.OrdersLines.Services
{
	public class UpdateOrderLineService : IService<UpdateOrderLineParameter, OrderLineDto>
	{
		private readonly IRepository<OrderLine> _orderLineRepository;
		private readonly OrderLineConverter _orderLineConverter;
		private readonly OrderLineDtoConverter _orderLineDtoConverter;

		public UpdateOrderLineService(
			IRepository<OrderLine> orderLineRepository,
			OrderLineConverter orderLineConverter,
			OrderLineDtoConverter orderLineDtoConverter)
		{
			_orderLineRepository = orderLineRepository;
			_orderLineConverter = orderLineConverter;
			_orderLineDtoConverter = orderLineDtoConverter;
		}

		public async Task<Result<OrderLineDto>> CallAsync(UpdateOrderLineParameter parameter)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			var orderLineToUpdate = await _orderLineRepository.GetAsync(parameter.OrderLine.Id);
			var updatedOrderLine = _orderLineConverter.Update(parameter.OrderLine, orderLineToUpdate);
			var updatedEntity = await _orderLineRepository.UpdateAsync(updatedOrderLine);
			var orderLineDto = _orderLineDtoConverter.Convert(updatedEntity);

			return new Result<OrderLineDto>(200, orderLineDto);
		}
	}
}