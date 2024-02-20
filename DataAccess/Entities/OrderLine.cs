namespace DataAccess.Entities
{
	public class OrderLine : BaseEntity
	{
		public int? OrderId { get; set; }
		public Order? Order { get; set; }
		public int? SubElementId { get; set; }
		public SubElement? SubElement { get; set; }
	}
}