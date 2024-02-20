using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Exceptions;
using OrderApp.Models.SubElements;
using OrderApp.Services;
using OrdersApp.Components.Models;
using OrdersApp.Components.Models.SubElements;

namespace OrdersApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubElementsController : ControllerBase
	{
		private readonly IService<ListSubElementParameter, List<SubElement>> _listSubElementService;
		private readonly IService<CreateSubElementParameter, SubElement> _createSubElementService;
		private readonly IService<UpdateSubElementParameter, SubElement> _updateSubElementService;
		private readonly IService<DeleteSubElementParameter, SubElement> _deleteSubElementService;

		public SubElementsController(
			IService<ListSubElementParameter, List<SubElement>> listSubElementService, 
			IService<CreateSubElementParameter, SubElement> createSubElementService, 
			IService<UpdateSubElementParameter, SubElement> updateSubElementService, 
			IService<DeleteSubElementParameter, SubElement> deleteSubElementService)
		{
			_listSubElementService = listSubElementService;
			_createSubElementService = createSubElementService;
			_updateSubElementService = updateSubElementService;
			_deleteSubElementService = deleteSubElementService;
		}

		[HttpGet]
		public async Task<IActionResult> ListAsync()
		{
			try
			{
				var result = await _listSubElementService.CallAsync(
					new ListSubElementParameter(10)
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
					new Result<SubElement>(
						500,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(SubElement subElement)
		{
			try
			{
				var result = await _createSubElementService.CallAsync(
					new CreateSubElementParameter(subElement)
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
					new Result<SubElement>(
						500,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(int id, SubElement subElement)
		{
			try
			{
				if (id != subElement.Id)
				{
					return BadRequest();
				}

				var result = await _updateSubElementService.CallAsync(
					new UpdateSubElementParameter(id, subElement)
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
					new Result<SubElement>(
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
				var result = await _deleteSubElementService.CallAsync(new DeleteSubElementParameter(id));

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
					new Result<SubElement>(
						500,
						null,
						new List<string>() { exception.Message }
					)
				);
			}
		}
	}
}