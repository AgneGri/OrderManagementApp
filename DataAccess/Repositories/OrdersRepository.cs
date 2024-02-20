using DataAccess.Entities;

namespace DataAccess.Repositories
{
	public class OrdersRepository : BaseRepository<Order>
	{
		public OrdersRepository(OrdersDbContext context) : base(context)
		{
		}
	}
}