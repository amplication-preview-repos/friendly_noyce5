using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.APIs.Dtos;

namespace DiscordBotDashboard.APIs;

public interface ICommandsService
{
    /// <summary>
    /// Create one Command
    /// </summary>
    public Task<Command> CreateCommand(CommandCreateInput command);

    /// <summary>
    /// Delete one Command
    /// </summary>
    public Task DeleteCommand(CommandWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Commands
    /// </summary>
    public Task<List<Command>> Commands(CommandFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Command records
    /// </summary>
    public Task<MetadataDto> CommandsMeta(CommandFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Command
    /// </summary>
    public Task<Command> Command(CommandWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Command
    /// </summary>
    public Task UpdateCommand(CommandWhereUniqueInput uniqueId, CommandUpdateInput updateDto);
}
