namespace OrderApp.Models.SubElements
{
	public class ListSubElementParameter
	{
		public ListSubElementParameter(int limit)
		{
			Limit = limit;
		}

		public int Limit { get; }
	}
}