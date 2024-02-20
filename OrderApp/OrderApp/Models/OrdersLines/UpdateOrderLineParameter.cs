using OrderApp.Models.OrdersLines.DTOs;

namespace OrdersApp.Components.Models.OrdersLines
{
	public class UpdateOrderLineParameter
	{
		public UpdateOrderLineParameter(int id, UpdateOrderLineDto orderLine)
		{
			Id = id;
			OrderLine = orderLine;
		}

		public int Id { get; }
		public UpdateOrderLineDto OrderLine { get; }
	}
}