using DataAccess.Entities;
using DataAccess.Repositories;
using OrderApp.Models.OrdersLines.DTO;
using OrderApp.Models.SubElements;
using OrderApp.Models.Windows;
using OrderApp.Services;
using OrderApp.Services.Orders;
using OrderApp.Services.OrdersLines.Converters;
using OrderApp.Services.OrdersLines.Services;
using OrderApp.Services.SubElements;
using OrderApp.Services.Windows;
using OrdersApp.Components.Models.Orders;
using OrdersApp.Components.Models.OrdersLines;
using OrdersApp.Components.Models.SubElements;
using OrdersApp.Components.Models.Windows;
using OrdersApp.Services.Orders;

namespace OrdersApp.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			RegisterRepositories(services);

			RegisterServices(services);

			RegisterConverters(services);

			return services;
		}

		private static void RegisterRepositories(IServiceCollection services)
		{
			services.AddScoped<IRepository<Order>, OrdersRepository>();
			services.AddScoped<IRepository<OrderLine>, OrdersLinesRepository>();
			services.AddScoped<IRepository<SubElement>, SubElementsRepository>();
			services.AddScoped<ISubElementRepository, SubElementsRepository>();
			services.AddScoped<IRepository<Window>, WindowsRepository>();
			services.AddScoped<IWindowRepository, WindowsRepository>();
		}

		private static void RegisterServices(IServiceCollection services)
		{
			#region Order
			services.AddScoped<IService<CreateOrderParameter, Order>, CreateOrderService>();
			services.AddScoped<IService<ListOrderParameter, List<Order>>, ListOrderService>();
			services.AddScoped<IService<UpdateOrderParameter, Order>, UpdateOrderService>();
			services.AddScoped<IService<DeleteOrderParameter, Order>, DeleteOrderService>();
			#endregion

			#region OrderLine
			services.AddScoped<IService<CreateOrderLineParameter, OrderLineDto>, CreateOrderLineService>();
			services.AddScoped<IService<ListOrderLineParameter, List<OrderLineDto>>, ListOrderLineService>();
			services.AddScoped<IService<UpdateOrderLineParameter, OrderLineDto>, UpdateOrderLineService>();
			services.AddScoped<IService<DeleteOrderLineParameter, OrderLineDto>, DeleteOrderLineService>();
			#endregion

			#region SubElement
			services.AddScoped<IService<CreateSubElementParameter, SubElement>, CreateSubElementService>();
			services.AddScoped<IService<ListSubElementParameter, List<SubElement>>, ListSubElementService>();
			services.AddScoped<IService<UpdateSubElementParameter, SubElement>, UpdateSubElementService>();
			services.AddScoped<IService<DeleteSubElementParameter, SubElement>, DeleteSubElementService>();
			#endregion

			#region Window
			services.AddScoped<IService<CreateWindowParameter, Window>, CreateWindowService>();
			services.AddScoped<IService<ListWindowParameter, List<Window>>, ListWindowService>();
			services.AddScoped<IService<UpdateWindowParameter, Window>, UpdateWindowService>();
			services.AddScoped<IService<DeleteWindowParameter, Window>, DeleteWindowService>();
			#endregion
		}

		private static void RegisterConverters(IServiceCollection services)
		{
			services.AddTransient<OrderLineConverter>();
			services.AddTransient<OrderLineDtoConverter>();
		}
	}
}