using DataAccess.Entities;

namespace OrderApp.Client.Models
{
	public class Response
	{
		public int Status { get; set; }
		public List<Order> Data { get; set; }
		public List<string> Errors { get; set; }
	}
}