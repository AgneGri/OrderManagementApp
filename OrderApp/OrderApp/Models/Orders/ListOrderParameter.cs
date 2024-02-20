namespace OrdersApp.Components.Models.Orders
{
	public class ListOrderParameter
	{
		public ListOrderParameter(int limit)
		{
			Limit = limit;
		}

		public int Limit { get; }
	}
}