using DataAccess.Entities;
using DataAccess.Repositories;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.Windows;

namespace OrderApp.Services.Windows
{
	public class UpdateWindowService : IService<UpdateWindowParameter, Window>
	{
		private readonly IRepository<Window> _windowRepository;

		public UpdateWindowService(IRepository<Window> windowRepository)
		{
			_windowRepository = windowRepository;
		}

		public async Task<Result<Window>> CallAsync(UpdateWindowParameter parameter)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			var result = await _windowRepository.UpdateAsync(parameter.Window);

			return new Result<Window>(200, result);
		}
	}
}