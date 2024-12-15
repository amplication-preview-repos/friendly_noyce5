using DiscordBotDashboard.APIs;
using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBotDashboard.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class LogsControllerBase : ControllerBase
{
    protected readonly ILogsService _service;

    public LogsControllerBase(ILogsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Log
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Log>> CreateLog(LogCreateInput input)
    {
        var log = await _service.CreateLog(input);

        return CreatedAtAction(nameof(Log), new { id = log.Id }, log);
    }

    /// <summary>
    /// Delete one Log
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteLog([FromRoute()] LogWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteLog(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Logs
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Log>>> Logs([FromQuery()] LogFindManyArgs filter)
    {
        return Ok(await _service.Logs(filter));
    }

    /// <summary>
    /// Meta data about Log records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> LogsMeta([FromQuery()] LogFindManyArgs filter)
    {
        return Ok(await _service.LogsMeta(filter));
    }

    /// <summary>
    /// Get one Log
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Log>> Log([FromRoute()] LogWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Log(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Log
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateLog(
        [FromRoute()] LogWhereUniqueInput uniqueId,
        [FromQuery()] LogUpdateInput logUpdateDto
    )
    {
        try
        {
            await _service.UpdateLog(uniqueId, logUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
