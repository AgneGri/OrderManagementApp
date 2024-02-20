using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	public class WindowsRepository : BaseRepository<Window>, IWindowRepository
	{
		public WindowsRepository(OrdersDbContext context) : base(context)
		{
		}

		public async Task<bool> DoesOrderIdExistAsync(int orderId)
		{
			return await _entities.AnyAsync(w => w.OrderId == orderId);
		}
	}
}