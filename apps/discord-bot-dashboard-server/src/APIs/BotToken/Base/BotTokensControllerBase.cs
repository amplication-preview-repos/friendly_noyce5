using DiscordBotDashboard.APIs;
using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBotDashboard.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class BotTokensControllerBase : ControllerBase
{
    protected readonly IBotTokensService _service;

    public BotTokensControllerBase(IBotTokensService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one BotToken
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<BotToken>> CreateBotToken(BotTokenCreateInput input)
    {
        var botToken = await _service.CreateBotToken(input);

        return CreatedAtAction(nameof(BotToken), new { id = botToken.Id }, botToken);
    }

    /// <summary>
    /// Delete one BotToken
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteBotToken([FromRoute()] BotTokenWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteBotToken(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many BotTokens
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<BotToken>>> BotTokens(
        [FromQuery()] BotTokenFindManyArgs filter
    )
    {
        return Ok(await _service.BotTokens(filter));
    }

    /// <summary>
    /// Meta data about BotToken records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> BotTokensMeta(
        [FromQuery()] BotTokenFindManyArgs filter
    )
    {
        return Ok(await _service.BotTokensMeta(filter));
    }

    /// <summary>
    /// Get one BotToken
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<BotToken>> BotToken(
        [FromRoute()] BotTokenWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.BotToken(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one BotToken
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateBotToken(
        [FromRoute()] BotTokenWhereUniqueInput uniqueId,
        [FromQuery()] BotTokenUpdateInput botTokenUpdateDto
    )
    {
        try
        {
            await _service.UpdateBotToken(uniqueId, botTokenUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
