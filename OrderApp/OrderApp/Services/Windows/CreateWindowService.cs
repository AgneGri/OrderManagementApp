using DataAccess.Entities;
using DataAccess.Repositories;
using OrderApp.Exceptions;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.Windows;

namespace OrderApp.Services.Windows
{
	public class CreateWindowService : IService<CreateWindowParameter, Window>
	{
		private readonly IWindowRepository _windowRepository;

		public CreateWindowService(IWindowRepository windowRepository)
		{
			_windowRepository = windowRepository;
		}

		public async Task<Result<Window>> CallAsync(CreateWindowParameter parameter)
		{
			if(parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			var doesOrderIdExist = await _windowRepository.DoesOrderIdExistAsync(parameter.Window.OrderId);

			if(!doesOrderIdExist)
			{
				throw new NotFoundException("The specified Order Id does not exist.");
			}

			var result = await _windowRepository.CreateAsync(parameter.Window);

			return new Result<Window>(200, result);
		}
	}
}