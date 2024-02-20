using DataAccess.Entities;
using DataAccess.Repositories;
using OrderApp.Models.SubElements;
using OrdersApp.Components.Models;

namespace OrderApp.Services.SubElements
{
	public class ListSubElementService : IService<ListSubElementParameter, List<SubElement>>
	{
		private readonly IRepository<SubElement> _subElementRepository;

		public ListSubElementService(IRepository<SubElement> subElementRepository)
		{
			_subElementRepository = subElementRepository;
		}

		public async Task<Result<List<SubElement>>> CallAsync(ListSubElementParameter parameter)
		{
			if(parameter == null)
			{
				throw new ArgumentNullException(nameof(parameter));
			}

			var result = await _subElementRepository.ListAsync();

			if (parameter.Limit != null)
			{
				result = result.Take((int)parameter.Limit).ToList();
			}

			return new Result<List<SubElement>>(200, result);
		}
	}
}