namespace OrderApp.Models.OrdersLines.DTOs
{
	public class UpdateOrderLineDto
	{
		public int Id { get; set; }
		public string? OrderName { get; set; }
		public string? OrderState { get; set; }

		public string? WindowName { get; set; }
		public int? WindowQuantityOfWindows { get; set; }
		public int? WindowTotalSubElements { get; set; }

		public string? SubElementType { get; set; }
		public int? SubElementWidth { get; set; }
		public int? SubElementHeight { get; set; }
	}
}