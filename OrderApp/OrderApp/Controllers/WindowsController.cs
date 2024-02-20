using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Exceptions;
using OrderApp.Models.Windows;
using OrderApp.Services;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.Windows;

namespace OrdersApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WindowsController : ControllerBase
	{
		private readonly IService<ListWindowParameter, List<Window>> _listWindowService;
		private readonly IService<CreateWindowParameter, Window> _createWindowService;
		private readonly IService<UpdateWindowParameter, Window> _updateWindowService;
		private readonly IService<DeleteWindowParameter, Window> _deleteWindowService;

		public WindowsController(
			IService<ListWindowParameter, List<Window>> listWindowService, 
			IService<CreateWindowParameter, Window> createWindowService, 
			IService<UpdateWindowParameter, Window> updateWindowService, 
			IService<DeleteWindowParameter, Window> deleteWindowService)
		{
			_listWindowService = listWindowService;
			_createWindowService = createWindowService;
			_updateWindowService = updateWindowService;
			_deleteWindowService = deleteWindowService;
		}

		[HttpGet]
		public async Task<IActionResult> ListAsync()
		{
			try
			{
				var result = await _listWindowService.CallAsync(
					new ListWindowParameter(10)
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
					new Result<Window>(
						500,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(Window window)
		{
			try
			{
				var result = await _createWindowService.CallAsync(
					new CreateWindowParameter(window)
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
					new Result<Window>(
						500,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(int id, Window window)
		{
			try
			{
				if (id != window.Id)
				{
					return BadRequest();
				}

				var result = await _updateWindowService.CallAsync(
					new UpdateWindowParameter(id, window)
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
					new Result<Window>(
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
				var result = await _deleteWindowService.CallAsync(new DeleteWindowParameter(id));

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
					new Result<Window>(
						500,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
		}
	}
}