using DataAccess.Entities;

namespace OrdersApp.Components.Models.Orders
{
	public class CreateOrderParameter
	{
		public CreateOrderParameter(Order order)
		{
			Order = order;
		}

		public Order Order { get; } 
	}
}