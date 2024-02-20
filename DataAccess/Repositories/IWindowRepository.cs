using DataAccess.Entities;

namespace DataAccess.Repositories
{
	public interface IWindowRepository : IRepository<Window>
	{
		Task<bool> DoesOrderIdExistAsync(int orderId);
	}
}