using DataAccess.Entities;

namespace DataAccess.Repositories
{
	public class OrdersLinesRepository : BaseRepository<OrderLine>
	{
		public OrdersLinesRepository(OrdersDbContext context) : base(context)
		{
		}
	}
}