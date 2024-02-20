using OrdersApp.Components.Models;

namespace OrderApp.Services
{
	public interface IService<TParameter, TData>
	{
		Task<Result<TData>> CallAsync(TParameter parameter);
	}
}