using DataAccess.Entities;
using DataAccess.Repositories;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.Windows;

namespace OrderApp.Services.Windows
{
	public class DeleteWindowService : IService<DeleteWindowParameter, Window>
	{
		private readonly IRepository<Window> _windowRepository;

		public DeleteWindowService(IRepository<Window> windowRepository)
		{
			_windowRepository = windowRepository;
		}

		public async Task<Result<Window>> CallAsync(DeleteWindowParameter parameter)
		{
			var result = await _windowRepository.DeleteAsync(parameter.Id);

			if (result)
			{
				return new Result<Window>(200, new Window());
			}

			return new Result<Window>(404, null);
		}
	}
}