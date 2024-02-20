using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Exceptions;
using OrderApp.Models.OrdersLines.DTO;
using OrderApp.Models.OrdersLines.DTOs;
using OrderApp.Services;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.OrdersLines;

namespace OrderApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersLinesController : ControllerBase
	{
		private readonly IService<ListOrderLineParameter, List<OrderLineDto>> _listOrderLineService;
		private readonly IService<CreateOrderLineParameter, OrderLineDto> _createOrderLineService;
		private readonly IService<UpdateOrderLineParameter, OrderLineDto> _updateOrderLineService;
		private readonly IService<DeleteOrderLineParameter, OrderLineDto> _deleteOrderLineService;

		public OrdersLinesController(
			IService<ListOrderLineParameter, List<OrderLineDto>> listOrderLineService, 
			IService<CreateOrderLineParameter, OrderLineDto> createOrderLineService, 
			IService<UpdateOrderLineParameter, OrderLineDto> updateOrderLineService, 
			IService<DeleteOrderLineParameter, OrderLineDto> deleteOrderLineService)
		{
			_listOrderLineService = listOrderLineService;
			_createOrderLineService = createOrderLineService;
			_updateOrderLineService = updateOrderLineService;
			_deleteOrderLineService = deleteOrderLineService;
		}

		[HttpGet]
		public async Task<IActionResult> ListAsync()
		{
			try
			{
				var result = await _listOrderLineService.CallAsync(
					new ListOrderLineParameter(10)
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
					new Result<OrderLineDto>(
						500,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(CreateOrderLineDto orderLine)
		{
			try
			{
				var result = await _createOrderLineService.CallAsync(
					new CreateOrderLineParameter(orderLine)
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
			catch (NotFoundException exception)
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
					new Result<OrderLineDto>(
						500,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(int id, UpdateOrderLineDto orderLine)
		{
			try
			{
				if (id != orderLine.Id)
				{
					return BadRequest();
				}

				var result = await _updateOrderLineService.CallAsync(
					new UpdateOrderLineParameter(id, orderLine)
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
					new Result<OrderLineDto>(
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
				var result = await _deleteOrderLineService.CallAsync(new DeleteOrderLineParameter(id));

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
					new Result<OrderLineDto>(
						500,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
		}
	}
}