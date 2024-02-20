using DataAccess.Entities;
using OrderApp.Models.OrdersLines.DTO;

namespace OrderApp.Services.OrdersLines.Converters
{
	public class OrderLineDtoConverter
	{
		public OrderLineDto Convert(OrderLine orderLine)
		{
			return new OrderLineDto
			{
				Id = orderLine.Id,
				OrderId = orderLine.OrderId,
				OrderName = orderLine.Order?.Name,
				OrderState = orderLine.Order?.State,
				WindowId = orderLine.SubElement?.Window?.Id,
				WindowName = orderLine.SubElement?.Window?.Name,
				WindowQuantityOfWindows = orderLine.SubElement?.Window?.QuantityOfWindows,
				WindowTotalSubElements = orderLine.SubElement?.Window?.TotalSubElements,
				SubElementId = orderLine.SubElementId,
				SubElementType = orderLine.SubElement?.Type,
				SubElementWidth = orderLine.SubElement?.Width,
				SubElementHeight = orderLine.SubElement?.Height
			};
		}
	}
}