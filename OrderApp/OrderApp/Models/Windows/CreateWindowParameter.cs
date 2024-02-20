using DataAccess.Entities;

namespace OrdersApp.Components.Models.Windows
{
	public class CreateWindowParameter
	{
		public CreateWindowParameter(Window window)
		{
			Window = window;
		}

		public Window Window { get; }
	}
}