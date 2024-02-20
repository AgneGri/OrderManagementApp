using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	public class SubElementsRepository : BaseRepository<SubElement>, ISubElementRepository
	{
		public SubElementsRepository(OrdersDbContext context) : base(context)
		{
		}

		public async Task<bool> DoesWindowIdExistAsync(int windowId)
		{
			return await _entities.AnyAsync(subElement => subElement.WindowId == windowId);
		}
	}
}