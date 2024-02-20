using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
	public class OrdersDbContext : DbContext
	{
		public OrdersDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Order> Orders { get; set; }
		public DbSet<Window> Windows { get; set; }
		public DbSet<SubElement> SubElements { get; set; }
		public DbSet<OrderLine> OrderLines { get; set; }
	}
}