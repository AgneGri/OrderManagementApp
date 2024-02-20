namespace OrderApp
{
	public class Response<TData>
	{
		public int Status { get; set; }
		public List<TData> Data { get; set; }
		public List<string> Errors { get; set; }
	}
}