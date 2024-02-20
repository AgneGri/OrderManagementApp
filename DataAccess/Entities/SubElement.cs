using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
	public class SubElement : BaseEntity
	{
		public int WindowId { get; set; }
		public Window? Window { get; set; }

		[Required]
		[MaxLength(25)]
		public string? Type { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
	}
}