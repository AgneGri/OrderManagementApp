using OrderApp.Models.OrdersLines.DTO;

namespace OrdersApp.Components.Models.OrdersLines
{
	public class CreateOrderLineParameter
	{
		public CreateOrderLineParameter(CreateOrderLineDto orderLine)
		{
			OrderLine = orderLine;
		}

		public CreateOrderLineDto OrderLine { get; }
	}
}