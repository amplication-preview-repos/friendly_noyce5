using DiscordBotDashboard.APIs;
using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.APIs.Errors;
using DiscordBotDashboard.APIs.Extensions;
using DiscordBotDashboard.Infrastructure;
using DiscordBotDashboard.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotDashboard.APIs;

public abstract class LogsServiceBase : ILogsService
{
    protected readonly DiscordBotDashboardDbContext _context;

    public LogsServiceBase(DiscordBotDashboardDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Log
    /// </summary>
    public async Task<Log> CreateLog(LogCreateInput createDto)
    {
        var log = new LogDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Message = createDto.Message,
            Timestamp = createDto.Timestamp,
            TypeField = createDto.TypeField,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            log.Id = createDto.Id;
        }

        _context.Logs.Add(log);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<LogDbModel>(log.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Log
    /// </summary>
    public async Task DeleteLog(LogWhereUniqueInput uniqueId)
    {
        var log = await _context.Logs.FindAsync(uniqueId.Id);
        if (log == null)
        {
            throw new NotFoundException();
        }

        _context.Logs.Remove(log);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Logs
    /// </summary>
    public async Task<List<Log>> Logs(LogFindManyArgs findManyArgs)
    {
        var logs = await _context
            .Logs.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return logs.ConvertAll(log => log.ToDto());
    }

    /// <summary>
    /// Meta data about Log records
    /// </summary>
    public async Task<MetadataDto> LogsMeta(LogFindManyArgs findManyArgs)
    {
        var count = await _context.Logs.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Log
    /// </summary>
    public async Task<Log> Log(LogWhereUniqueInput uniqueId)
    {
        var logs = await this.Logs(
            new LogFindManyArgs { Where = new LogWhereInput { Id = uniqueId.Id } }
        );
        var log = logs.FirstOrDefault();
        if (log == null)
        {
            throw new NotFoundException();
        }

        return log;
    }

    /// <summary>
    /// Update one Log
    /// </summary>
    public async Task UpdateLog(LogWhereUniqueInput uniqueId, LogUpdateInput updateDto)
    {
        var log = updateDto.ToModel(uniqueId);

        _context.Entry(log).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Logs.Any(e => e.Id == log.Id))
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
