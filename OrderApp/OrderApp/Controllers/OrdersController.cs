using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Services;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.Orders;

namespace OrdersApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IService<ListOrderParameter, List<Order>> _listOrderService;
		private readonly IService<CreateOrderParameter, Order> _createOrderService;
		private readonly IService<UpdateOrderParameter, Order> _updateOrderService;
		private readonly IService<DeleteOrderParameter, Order> _deleteOrderService;

		public OrdersController(
			IService<ListOrderParameter, List<Order>> listOrderService,
			IService<CreateOrderParameter, Order> createOrderService,
			IService<UpdateOrderParameter, Order> updateOrderService,
			IService<DeleteOrderParameter, Order> deleteOrderService)
		{
			_listOrderService = listOrderService;
			_createOrderService = createOrderService;
			_updateOrderService = updateOrderService;
			_deleteOrderService = deleteOrderService;
		}

		[HttpGet]
		public async Task<IActionResult> ListAsync()
		{
			try
			{
				var result = await _listOrderService.CallAsync(
					new ListOrderParameter(10)
					);

				return Ok(result);
			}
			catch (ArgumentNullException exception)
			{
				return StatusCode(
					404,
					new Result<Window>(
						404,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
			catch (Exception exception)
			{
				return StatusCode(
					500,
					new Result<Order>(
						500,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(Order order)
		{
			try
			{
				var result = await _createOrderService.CallAsync(
					new CreateOrderParameter(order)
				);

				return Ok(result);
			}
			catch (ArgumentNullException exception)
			{
				return StatusCode(
					404,
					new Result<Window>(
						404,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
			catch (Exception exception)
			{
				return StatusCode(
					500,
					new Result<Order>(
						500,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(int id, Order order)
		{
			try
			{
				if (id != order.Id)
				{
					return BadRequest();
				}

				var result = await _updateOrderService.CallAsync(
					new UpdateOrderParameter(id, order)
				);

				return Ok(result);
			}
			catch (ArgumentNullException exception)
			{
				return StatusCode(
					404,
					new Result<Window>(
						404,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
			catch (Exception exception)
			{
				return StatusCode(
					500,
					new Result<Order>(
						500,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			try
			{
				var result = await _deleteOrderService.CallAsync(new DeleteOrderParameter(id));

				if (result.Data == null)
				{
					return NotFound();
				}

				return NoContent();
			}
			catch (Exception exception)
			{
				return StatusCode(
					500,
					new Result<Order>(
						500,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
		}
	}
}