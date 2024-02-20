using DataAccess.Entities;
using DataAccess.Repositories;
using OrderApp.Models.OrdersLines.DTO;
using OrderApp.Services.OrdersLines.Converters;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.OrdersLines;

namespace OrderApp.Services.OrdersLines.Services
{
	public class ListOrderLineService : IService<ListOrderLineParameter, List<OrderLineDto>>
	{
		private readonly IRepository<OrderLine> _orderLineRepository;
		private readonly OrderLineDtoConverter _orderLineDtoConverter;

		public ListOrderLineService(
			IRepository<OrderLine> orderLineRepository,
			OrderLineDtoConverter orderLineDtoConverter)
		{
			_orderLineRepository = orderLineRepository;
			_orderLineDtoConverter = orderLineDtoConverter;
		}

		public async Task<Result<List<OrderLineDto>>> CallAsync(ListOrderLineParameter parameter)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			var result = await _orderLineRepository.ListAsync(
				ol => ol.Order, 
				ol => ol.SubElement, 
				ol => ol.SubElement.Window
			);

			if (parameter.Limit != null)
			{
				result = result.Take(parameter.Limit).ToList();
			}

			var orderLinesDtos = result.Select(_orderLineDtoConverter.Convert).ToList();

			return new Result<List<OrderLineDto>>(200, orderLinesDtos);
		}
	}
}