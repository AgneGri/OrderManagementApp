using DataAccess.Entities;
using DataAccess.Repositories;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.SubElements;

namespace OrderApp.Services.SubElements
{
	public class UpdateSubElementService : IService<UpdateSubElementParameter, SubElement>
	{
		private readonly IRepository<SubElement> _subElementRepository;

		public UpdateSubElementService(IRepository<SubElement> subElementRepository)
		{
			_subElementRepository = subElementRepository;
		}

		public async Task<Result<SubElement>> CallAsync(UpdateSubElementParameter parameter)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			var result = await _subElementRepository.UpdateAsync(parameter.SubElement);

			return new Result<SubElement>(200, result);
		}
	}
}