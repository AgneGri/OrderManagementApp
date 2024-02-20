using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
	public class BaseRepository<TEntity> : IRepository<TEntity>
		where TEntity : BaseEntity
	{
		protected OrdersDbContext _context;
		protected DbSet<TEntity> _entities;

		public BaseRepository(OrdersDbContext context)
		{
			_context = context;
			_entities = _context.Set<TEntity>();
		}

		public async Task<List<TEntity>> ListAsync(params Expression<Func<TEntity, object>>[] includes)
		{
			IQueryable<TEntity> query = _entities;

			if (includes != null)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}

			return await query.ToListAsync();
		}

		public async Task<TEntity> CreateAsync(TEntity entity)
		{
			await _entities.AddAsync(entity);
			await _context.SaveChangesAsync();

			return entity;
		}

		public async Task<TEntity> GetAsync(int id)
		{
			return await _entities.FindAsync(id);
		}

		public async Task<TEntity> GetAsync(int id, params Expression<Func<TEntity, object>>[] includes)
		{
			IQueryable<TEntity> query = _entities;

			foreach (var include in includes)
			{
				query = query.Include(include);
			}

			return await query.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			_entities.Update(entity);
			await _context.SaveChangesAsync();

			return entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			TEntity entity = await GetAsync(id);

			if (entity == null)
			{
				return false;
			}

			_entities.Remove(entity);
			await _context.SaveChangesAsync();

			return true;
		}
	}
}