using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.Infrastructure.Models;

namespace DiscordBotDashboard.APIs.Extensions;

public static class LogsExtensions
{
    public static Log ToDto(this LogDbModel model)
    {
        return new Log
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Message = model.Message,
            Timestamp = model.Timestamp,
            TypeField = model.TypeField,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static LogDbModel ToModel(this LogUpdateInput updateDto, LogWhereUniqueInput uniqueId)
    {
        var log = new LogDbModel
        {
            Id = uniqueId.Id,
            Message = updateDto.Message,
            Timestamp = updateDto.Timestamp,
            TypeField = updateDto.TypeField
        };

        if (updateDto.CreatedAt != null)
        {
            log.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            log.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return log;
    }
}
