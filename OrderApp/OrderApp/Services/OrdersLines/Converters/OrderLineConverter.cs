using DataAccess.Entities;
using DataAccess.Repositories;
using OrderApp.Exceptions;
using OrderApp.Models.OrdersLines.DTO;
using OrderApp.Models.OrdersLines.DTOs;

namespace OrderApp.Services.OrdersLines.Converters
{
	public class OrderLineConverter
	{
		private readonly IRepository<Order> _orderRepository;
		private readonly IRepository<SubElement> _subElementRepository;

		public OrderLineConverter(
			IRepository<Order> orderRepository, 
			IRepository<SubElement> subElementRepository)
		{
			_orderRepository = orderRepository;
			_subElementRepository = subElementRepository;
		}

		public async Task<OrderLine> Create(CreateOrderLineDto orderLineDto)
		{
			var order = await _orderRepository.GetAsync(orderLineDto.OrderId);
			
			if (order == null)
			{
				throw new NotFoundException($"The specified Order Id {orderLineDto.OrderId} " +
					$"does not exist. Please enter a valid Order Id."
				);
			}

			var subElement = await _subElementRepository.GetAsync(
				orderLineDto.SubElementId,
				se => se.Window
			); 

			if (subElement == null)
			{
				throw new NotFoundException($"SubElement or Window with specified Id " +
					$"does not exist. Please enter a valid Id."
				);
			}

			var orderLine = new OrderLine
			{
				OrderId = order.Id,
				Order = order,
				SubElementId = subElement.Id,
				SubElement = subElement
			};

			return orderLine;
		}

		public OrderLine Update(UpdateOrderLineDto orderLineDto, OrderLine orderLineEntity)
		{
			if (orderLineEntity.Order != null)
			{
				orderLineEntity.Order.Name = orderLineDto.OrderName;
				orderLineEntity.Order.State = orderLineDto.OrderState;
			}

			if (orderLineEntity.SubElement != null)
			{
				orderLineEntity.SubElement.Type = orderLineDto.SubElementType;
				orderLineEntity.SubElement.Width = (int)orderLineDto.SubElementWidth;
				orderLineEntity.SubElement.Height = (int)orderLineDto.SubElementHeight;
				orderLineEntity.SubElement.Window.Name = orderLineDto.WindowName;
				orderLineEntity.SubElement.Window.QuantityOfWindows = (int)orderLineDto.WindowQuantityOfWindows;
				orderLineEntity.SubElement.Window.TotalSubElements = (int)orderLineDto.WindowTotalSubElements;
			}

			return orderLineEntity;
		}
	}
}