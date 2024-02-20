using DataAccess.Entities;
using DataAccess.Repositories;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.SubElements;

namespace OrderApp.Services.SubElements
{
	public class DeleteSubElementService : IService<DeleteSubElementParameter, SubElement>
	{
		private readonly IRepository<SubElement> _subElementRepository;

		public DeleteSubElementService(IRepository<SubElement> subElementRepository)
		{
			_subElementRepository = subElementRepository;
		}

		public async Task<Result<SubElement>> CallAsync(DeleteSubElementParameter parameter)
		{
			var result = await _subElementRepository.DeleteAsync(parameter.Id);

			if(result)
			{
				return new Result<SubElement>(200, new SubElement());
			}

			return new Result<SubElement>(404, null);
		}
	}
}