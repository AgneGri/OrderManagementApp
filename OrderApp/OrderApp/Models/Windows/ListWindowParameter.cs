namespace OrderApp.Models.Windows
{
	public class ListWindowParameter
	{
		public ListWindowParameter(int limit)
		{
			Limit = limit;
		}

		public int Limit { get; }
	}
}