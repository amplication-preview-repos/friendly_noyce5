using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.APIs.Dtos;

namespace DiscordBotDashboard.APIs;

public interface ILogsService
{
    /// <summary>
    /// Create one Log
    /// </summary>
    public Task<Log> CreateLog(LogCreateInput log);

    /// <summary>
    /// Delete one Log
    /// </summary>
    public Task DeleteLog(LogWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Logs
    /// </summary>
    public Task<List<Log>> Logs(LogFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Log records
    /// </summary>
    public Task<MetadataDto> LogsMeta(LogFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Log
    /// </summary>
    public Task<Log> Log(LogWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Log
    /// </summary>
    public Task UpdateLog(LogWhereUniqueInput uniqueId, LogUpdateInput updateDto);
}
