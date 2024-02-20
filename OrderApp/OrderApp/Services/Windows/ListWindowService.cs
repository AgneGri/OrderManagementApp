using DataAccess.Entities;
using DataAccess.Repositories;
using OrderApp.Models.Windows;
using OrdersApp.Components.Models;

namespace OrderApp.Services.Windows
{
	public class ListWindowService : IService<ListWindowParameter, List<Window>>
	{
		private readonly IRepository<Window> _windowRepository;

		public ListWindowService(IRepository<Window> windowRepository)
		{
			_windowRepository = windowRepository;
		}

		public async Task<Result<List<Window>>> CallAsync(ListWindowParameter parameter)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			var result = await _windowRepository.ListAsync();

			if (parameter.Limit != null)
			{
				result = result.Take((int)parameter.Limit).ToList();
			}

			return new Result<List<Window>>(200, result);
		}
	}
}