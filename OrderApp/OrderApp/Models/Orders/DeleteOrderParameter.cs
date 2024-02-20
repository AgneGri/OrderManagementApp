namespace OrdersApp.Components.Models.Orders
{
	public class DeleteOrderParameter
	{
		public DeleteOrderParameter(int id)
		{
			Id = id;
		}

		public int Id { get; }
	}
}