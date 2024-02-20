using System.Linq.Expressions;

namespace DataAccess.Repositories
{
	public interface IRepository<TEntity>
	{
		Task<List<TEntity>> ListAsync(params Expression<Func<TEntity, object>>[] includes);

		Task<TEntity> CreateAsync(TEntity entity);

		Task<TEntity?> GetAsync(int id);

		Task<TEntity> GetAsync(int id, params Expression<Func<TEntity, object>>[] includes);

		Task<TEntity> UpdateAsync(TEntity entity);

		Task<bool> DeleteAsync(int id);
	}
}