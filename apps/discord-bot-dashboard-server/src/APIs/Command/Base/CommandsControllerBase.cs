using DiscordBotDashboard.APIs;
using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBotDashboard.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CommandsControllerBase : ControllerBase
{
    protected readonly ICommandsService _service;

    public CommandsControllerBase(ICommandsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Command
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Command>> CreateCommand(CommandCreateInput input)
    {
        var command = await _service.CreateCommand(input);

        return CreatedAtAction(nameof(Command), new { id = command.Id }, command);
    }

    /// <summary>
    /// Delete one Command
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCommand([FromRoute()] CommandWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteCommand(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Commands
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Command>>> Commands(
        [FromQuery()] CommandFindManyArgs filter
    )
    {
        return Ok(await _service.Commands(filter));
    }

    /// <summary>
    /// Meta data about Command records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CommandsMeta(
        [FromQuery()] CommandFindManyArgs filter
    )
    {
        return Ok(await _service.CommandsMeta(filter));
    }

    /// <summary>
    /// Get one Command
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Command>> Command([FromRoute()] CommandWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Command(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Command
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCommand(
        [FromRoute()] CommandWhereUniqueInput uniqueId,
        [FromQuery()] CommandUpdateInput commandUpdateDto
    )
    {
        try
        {
            await _service.UpdateCommand(uniqueId, commandUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
