using DiscordBotDashboard.APIs;
using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBotDashboard.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SuggestionsControllerBase : ControllerBase
{
    protected readonly ISuggestionsService _service;

    public SuggestionsControllerBase(ISuggestionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Suggestion
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Suggestion>> CreateSuggestion(SuggestionCreateInput input)
    {
        var suggestion = await _service.CreateSuggestion(input);

        return CreatedAtAction(nameof(Suggestion), new { id = suggestion.Id }, suggestion);
    }

    /// <summary>
    /// Delete one Suggestion
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteSuggestion(
        [FromRoute()] SuggestionWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteSuggestion(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Suggestions
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Suggestion>>> Suggestions(
        [FromQuery()] SuggestionFindManyArgs filter
    )
    {
        return Ok(await _service.Suggestions(filter));
    }

    /// <summary>
    /// Meta data about Suggestion records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SuggestionsMeta(
        [FromQuery()] SuggestionFindManyArgs filter
    )
    {
        return Ok(await _service.SuggestionsMeta(filter));
    }

    /// <summary>
    /// Get one Suggestion
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Suggestion>> Suggestion(
        [FromRoute()] SuggestionWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Suggestion(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Suggestion
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateSuggestion(
        [FromRoute()] SuggestionWhereUniqueInput uniqueId,
        [FromQuery()] SuggestionUpdateInput suggestionUpdateDto
    )
    {
        try
        {
            await _service.UpdateSuggestion(uniqueId, suggestionUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
