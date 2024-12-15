using DiscordBotDashboard.APIs;
using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.APIs.Errors;
using DiscordBotDashboard.APIs.Extensions;
using DiscordBotDashboard.Infrastructure;
using DiscordBotDashboard.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotDashboard.APIs;

public abstract class SuggestionsServiceBase : ISuggestionsService
{
    protected readonly DiscordBotDashboardDbContext _context;

    public SuggestionsServiceBase(DiscordBotDashboardDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Suggestion
    /// </summary>
    public async Task<Suggestion> CreateSuggestion(SuggestionCreateInput createDto)
    {
        var suggestion = new SuggestionDbModel
        {
            AdminFeedback = createDto.AdminFeedback,
            BriefDescription = createDto.BriefDescription,
            CreatedAt = createDto.CreatedAt,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt,
            Username = createDto.Username
        };

        if (createDto.Id != null)
        {
            suggestion.Id = createDto.Id;
        }

        _context.Suggestions.Add(suggestion);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<SuggestionDbModel>(suggestion.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Suggestion
    /// </summary>
    public async Task DeleteSuggestion(SuggestionWhereUniqueInput uniqueId)
    {
        var suggestion = await _context.Suggestions.FindAsync(uniqueId.Id);
        if (suggestion == null)
        {
            throw new NotFoundException();
        }

        _context.Suggestions.Remove(suggestion);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Suggestions
    /// </summary>
    public async Task<List<Suggestion>> Suggestions(SuggestionFindManyArgs findManyArgs)
    {
        var suggestions = await _context
            .Suggestions.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return suggestions.ConvertAll(suggestion => suggestion.ToDto());
    }

    /// <summary>
    /// Meta data about Suggestion records
    /// </summary>
    public async Task<MetadataDto> SuggestionsMeta(SuggestionFindManyArgs findManyArgs)
    {
        var count = await _context.Suggestions.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Suggestion
    /// </summary>
    public async Task<Suggestion> Suggestion(SuggestionWhereUniqueInput uniqueId)
    {
        var suggestions = await this.Suggestions(
            new SuggestionFindManyArgs { Where = new SuggestionWhereInput { Id = uniqueId.Id } }
        );
        var suggestion = suggestions.FirstOrDefault();
        if (suggestion == null)
        {
            throw new NotFoundException();
        }

        return suggestion;
    }

    /// <summary>
    /// Update one Suggestion
    /// </summary>
    public async Task UpdateSuggestion(
        SuggestionWhereUniqueInput uniqueId,
        SuggestionUpdateInput updateDto
    )
    {
        var suggestion = updateDto.ToModel(uniqueId);

        _context.Entry(suggestion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Suggestions.Any(e => e.Id == suggestion.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
