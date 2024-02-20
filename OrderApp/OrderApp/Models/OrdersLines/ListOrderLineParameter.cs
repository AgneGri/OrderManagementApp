namespace OrdersApp.Components.Models.OrdersLines
{
	public class ListOrderLineParameter
	{
		public ListOrderLineParameter(int limit)
		{
			Limit = limit;
		}

		public int Limit { get; }
	}
}