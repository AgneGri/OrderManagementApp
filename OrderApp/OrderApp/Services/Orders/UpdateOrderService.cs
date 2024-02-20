using DataAccess.Entities;
using DataAccess.Repositories;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.Orders;

namespace OrderApp.Services.Orders
{
	public class UpdateOrderService : IService<UpdateOrderParameter, Order>
	{
		private readonly IRepository<Order> _orderRepository;

		public UpdateOrderService(IRepository<Order> orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<Result<Order>> CallAsync(UpdateOrderParameter parameter)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			var result = await _orderRepository.UpdateAsync(parameter.Order);

			return new Result<Order>(200, result);
		}
	}
}