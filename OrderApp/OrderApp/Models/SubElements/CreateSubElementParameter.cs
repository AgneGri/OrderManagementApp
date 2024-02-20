using DataAccess.Entities;

namespace OrdersApp.Components.Models.SubElements
{
	public class CreateSubElementParameter
	{
		public CreateSubElementParameter(SubElement subElement)
		{
			SubElement = subElement;
		}

		public SubElement SubElement { get; }
	}
}