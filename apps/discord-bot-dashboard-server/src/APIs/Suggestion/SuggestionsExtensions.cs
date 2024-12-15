using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.Infrastructure.Models;

namespace DiscordBotDashboard.APIs.Extensions;

public static class SuggestionsExtensions
{
    public static Suggestion ToDto(this SuggestionDbModel model)
    {
        return new Suggestion
        {
            AdminFeedback = model.AdminFeedback,
            BriefDescription = model.BriefDescription,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
            Username = model.Username,
        };
    }

    public static SuggestionDbModel ToModel(
        this SuggestionUpdateInput updateDto,
        SuggestionWhereUniqueInput uniqueId
    )
    {
        var suggestion = new SuggestionDbModel
        {
            Id = uniqueId.Id,
            AdminFeedback = updateDto.AdminFeedback,
            BriefDescription = updateDto.BriefDescription,
            Status = updateDto.Status,
            Username = updateDto.Username
        };

        if (updateDto.CreatedAt != null)
        {
            suggestion.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            suggestion.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return suggestion;
    }
}
