using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.Infrastructure.Models;

namespace DiscordBotDashboard.APIs.Extensions;

public static class BotTokensExtensions
{
    public static BotToken ToDto(this BotTokenDbModel model)
    {
        return new BotToken
        {
            CreatedAt = model.CreatedAt,
            CreatedDate = model.CreatedDate,
            Id = model.Id,
            Token = model.Token,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static BotTokenDbModel ToModel(
        this BotTokenUpdateInput updateDto,
        BotTokenWhereUniqueInput uniqueId
    )
    {
        var botToken = new BotTokenDbModel
        {
            Id = uniqueId.Id,
            CreatedDate = updateDto.CreatedDate,
            Token = updateDto.Token
        };

        if (updateDto.CreatedAt != null)
        {
            botToken.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            botToken.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return botToken;
    }
}
