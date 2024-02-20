using DataAccess.Entities;
using DataAccess.Repositories;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.Orders;

namespace OrderApp.Services.Orders
{
	public class CreateOrderService : IService<CreateOrderParameter, Order>
	{
		private readonly IRepository<Order> _orderRepository;

		public CreateOrderService(IRepository<Order> orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<Result<Order>> CallAsync(CreateOrderParameter parameter)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			var result = await _orderRepository.CreateAsync(parameter.Order);

			return new Result<Order>(200, result);
		}
	}
}