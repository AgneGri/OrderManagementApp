using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
	public class Order : BaseEntity
	{
		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required]
		[MaxLength(2)]
		public string State { get; set; }
	}
}