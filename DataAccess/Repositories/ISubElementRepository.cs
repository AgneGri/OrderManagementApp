using DataAccess.Entities;

namespace DataAccess.Repositories
{
	public interface ISubElementRepository : IRepository<SubElement>
	{
		Task<bool> DoesWindowIdExistAsync(int windowId);
	}
}