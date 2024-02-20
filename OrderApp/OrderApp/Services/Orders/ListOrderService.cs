using DataAccess.Entities;
using DataAccess.Repositories;
using OrderApp.Services;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.Orders;

namespace OrdersApp.Services.Orders
{
	public class ListOrderService : IService<ListOrderParameter, List<Order>>
	{
		private readonly IRepository<Order> _orderRepository;

		public ListOrderService(IRepository<Order> orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<Result<List<Order>>> CallAsync(ListOrderParameter parameter)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			var result = await _orderRepository.ListAsync();

			if (parameter.Limit != null)
			{
				result = result.Take((int)parameter.Limit).ToList();
			}

			return new Result<List<Order>>(200, result);
		}
	}
}