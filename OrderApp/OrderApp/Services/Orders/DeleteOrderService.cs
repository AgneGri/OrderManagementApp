using DataAccess.Entities;
using DataAccess.Repositories;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.Orders;

namespace OrderApp.Services.Orders
{
	public class DeleteOrderService : IService<DeleteOrderParameter, Order>
	{
		private readonly IRepository<Order> _orderRepository;

		public DeleteOrderService(IRepository<Order> orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<Result<Order>> CallAsync(DeleteOrderParameter parameter)
		{
			var result = await _orderRepository.DeleteAsync(parameter.Id);

			if(result)
			{
				return new Result<Order>(200, new Order());
			}

			return new Result<Order>(404, null);
		}
	}
}