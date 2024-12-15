using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.APIs.Dtos;

namespace DiscordBotDashboard.APIs;

public interface ISuggestionsService
{
    /// <summary>
    /// Create one Suggestion
    /// </summary>
    public Task<Suggestion> CreateSuggestion(SuggestionCreateInput suggestion);

    /// <summary>
    /// Delete one Suggestion
    /// </summary>
    public Task DeleteSuggestion(SuggestionWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Suggestions
    /// </summary>
    public Task<List<Suggestion>> Suggestions(SuggestionFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Suggestion records
    /// </summary>
    public Task<MetadataDto> SuggestionsMeta(SuggestionFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Suggestion
    /// </summary>
    public Task<Suggestion> Suggestion(SuggestionWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Suggestion
    /// </summary>
    public Task UpdateSuggestion(
        SuggestionWhereUniqueInput uniqueId,
        SuggestionUpdateInput updateDto
    );
}
