using DataAccess.Entities;

namespace OrdersApp.Components.Models.Orders
{
	public class UpdateOrderParameter
	{
		public UpdateOrderParameter(int id, Order order)
		{
			Id = id;
			Order = order;
		}

		public int Id { get; }
		public Order Order { get; }
	}
}