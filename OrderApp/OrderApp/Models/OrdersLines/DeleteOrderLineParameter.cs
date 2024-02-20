namespace OrdersApp.Components.Models.OrdersLines
{
	public class DeleteOrderLineParameter
	{
		public DeleteOrderLineParameter(int id)
		{
			Id = id;
		}

		public int Id { get; }
	}
}