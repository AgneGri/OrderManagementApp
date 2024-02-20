using DataAccess.Entities;

namespace OrdersApp.Components.Models.Windows
{
	public class UpdateWindowParameter
	{
		public UpdateWindowParameter(int id, Window window)
		{
			Id = id;
			Window = window;
		}

		public int Id { get; }
		public Window Window { get; }
	}
}