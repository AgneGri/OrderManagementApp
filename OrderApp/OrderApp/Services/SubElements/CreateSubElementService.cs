using DataAccess.Entities;
using DataAccess.Repositories;
using OrderApp.Exceptions;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.SubElements;

namespace OrderApp.Services.SubElements
{
	public class CreateSubElementService : IService<CreateSubElementParameter, SubElement>
	{
		private readonly ISubElementRepository _subElementRepository;

		public CreateSubElementService(ISubElementRepository subElementRepository)
		{
			_subElementRepository = subElementRepository;
		}

		public async Task<Result<SubElement>> CallAsync(CreateSubElementParameter parameter)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			var doesWindowIdExist = await _subElementRepository.DoesWindowIdExistAsync(parameter.SubElement.WindowId);

			if(!doesWindowIdExist)
			{
				throw new NotFoundException("The specified Window Id does not exist.");
			}

			var result = await _subElementRepository.CreateAsync(parameter.SubElement);

			return new Result<SubElement>(200, result);
		}
	}
}