using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
	public class Window : BaseEntity
	{
		public int OrderId { get; set; }
		public Order? Order { get; set; }

		[Required]
		[MaxLength(25)]
		public string Name { get; set; }
		public int QuantityOfWindows { get; set; }
		public int TotalSubElements { get; set; }
	}
}