namespace OrderApp.Models.OrdersLines.DTO
{
	public class CreateOrderLineDto
	{
		public int OrderId { get; set; }
		public string? OrderName { get; set; }
		public string? OrderState { get; set; }
		public int WindowId { get; set; }

		public string? WindowName { get; set; }
		public int? WindowQuantityOfWindows { get; set; }
		public int? WindowTotalSubElements { get; set; }
		public int SubElementId { get; set; }

		public string? SubElementType { get; set; }
		public int? SubElementWidth { get; set; }
		public int? SubElementHeight { get; set; }
	}
}