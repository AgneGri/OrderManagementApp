using DataAccess.Entities;

namespace OrdersApp.Components.Models.SubElements
{
	public class UpdateSubElementParameter
	{
		public UpdateSubElementParameter(int id, SubElement subElement)
		{
			Id = id;
			SubElement = subElement;
		}

		public int Id { get; }
		public SubElement SubElement { get; }
	}
}