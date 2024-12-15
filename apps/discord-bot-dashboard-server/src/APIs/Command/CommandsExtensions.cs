using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.Infrastructure.Models;

namespace DiscordBotDashboard.APIs.Extensions;

public static class CommandsExtensions
{
    public static Command ToDto(this CommandDbModel model)
    {
        return new Command
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            IsActive = model.IsActive,
            Name = model.Name,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CommandDbModel ToModel(
        this CommandUpdateInput updateDto,
        CommandWhereUniqueInput uniqueId
    )
    {
        var command = new CommandDbModel
        {
            Id = uniqueId.Id,
            IsActive = updateDto.IsActive,
            Name = updateDto.Name
        };

        if (updateDto.CreatedAt != null)
        {
            command.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            command.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return command;
    }
}
