using Microsoft.AspNetCore.Mvc;
using PackIT.Application.Commands;
using PackIT.Application.DTO;
using PackIT.Application.Exceptions;
using PackIT.Application.Queries;
using PackIT.Shared.Abstraction.Commands;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Api.Controllers;

public class PackingListController(
    ICommandDispatcher commandDispatcher,
    IQueryDispatcher queryDispatcher) : BaseController
{
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<PackingListDto>> Get([FromRoute] GetPackingList query)
    {
        try
        {
            var result = await queryDispatcher.QueryAsync(query);

            return OkOrNotFound(result);
        }
        catch (PackingListNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return Problem(
                detail: ex.StackTrace,
                title: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError,
                type: $"{typeof(Exception)}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PackingListDto>>> Get([FromRoute] SearchPackingList query)
    {
        try
        {
            var result = await queryDispatcher.QueryAsync(query);

            return OkOrNotFound(result);
        }
        catch (Exception ex)
        {
            return Problem(
                detail: ex.StackTrace,
                title: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError,
                type: $"{typeof(Exception)}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePackingListWithItems command)
    {
        try
        {
            await commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }
        catch(PackingListAlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        }
        catch(MissingLocalizationWeatherException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return Problem(
                detail: ex.StackTrace,
                title: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError,
                type: $"{typeof(Exception)}");
        }
    }

    [HttpPut]
    [Route("{packingListId:guid}/items")]
    public async Task<IActionResult> Put([FromBody] AddPackingItem command)
    {
        try
        {
            await commandDispatcher.DispatchAsync(command);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(
                detail: ex.StackTrace,
                title: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError,
                type: $"{typeof(Exception)}");
        }
    }

    [HttpPut]
    [Route("{packingListId:guid}/items/{name}/pack")]
    public async Task<IActionResult> Put([FromBody] PackItem command)
    {
        try
        {
            await commandDispatcher.DispatchAsync(command);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(
                detail: ex.StackTrace,
                title: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError,
                type: $"{typeof(Exception)}");
        }
    }

    [HttpDelete]
    [Route("{packingListId:guid}/items/{name}")]
    public async Task<IActionResult> Delete([FromBody] RemovePackingItem command)
    {
        try
        {
            await commandDispatcher.DispatchAsync(command);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(
                detail: ex.StackTrace,
                title: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError,
                type: $"{typeof(Exception)}");
        }
    }

    [HttpDelete]
    [Route("{packingListId:guid}")]
    public async Task<IActionResult> Delete([FromBody] DeletePackingList command)
    {
        try
        {
            await commandDispatcher.DispatchAsync(command);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(
                detail: ex.StackTrace,
                title: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError,
                type: $"{typeof(Exception)}");
        }
    }
}
