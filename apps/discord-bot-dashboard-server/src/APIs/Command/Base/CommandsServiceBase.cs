using DiscordBotDashboard.APIs;
using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.APIs.Errors;
using DiscordBotDashboard.APIs.Extensions;
using DiscordBotDashboard.Infrastructure;
using DiscordBotDashboard.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotDashboard.APIs;

public abstract class CommandsServiceBase : ICommandsService
{
    protected readonly DiscordBotDashboardDbContext _context;

    public CommandsServiceBase(DiscordBotDashboardDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Command
    /// </summary>
    public async Task<Command> CreateCommand(CommandCreateInput createDto)
    {
        var command = new CommandDbModel
        {
            CreatedAt = createDto.CreatedAt,
            IsActive = createDto.IsActive,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            command.Id = createDto.Id;
        }

        _context.Commands.Add(command);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CommandDbModel>(command.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Command
    /// </summary>
    public async Task DeleteCommand(CommandWhereUniqueInput uniqueId)
    {
        var command = await _context.Commands.FindAsync(uniqueId.Id);
        if (command == null)
        {
            throw new NotFoundException();
        }

        _context.Commands.Remove(command);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Commands
    /// </summary>
    public async Task<List<Command>> Commands(CommandFindManyArgs findManyArgs)
    {
        var commands = await _context
            .Commands.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return commands.ConvertAll(command => command.ToDto());
    }

    /// <summary>
    /// Meta data about Command records
    /// </summary>
    public async Task<MetadataDto> CommandsMeta(CommandFindManyArgs findManyArgs)
    {
        var count = await _context.Commands.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Command
    /// </summary>
    public async Task<Command> Command(CommandWhereUniqueInput uniqueId)
    {
        var commands = await this.Commands(
            new CommandFindManyArgs { Where = new CommandWhereInput { Id = uniqueId.Id } }
        );
        var command = commands.FirstOrDefault();
        if (command == null)
        {
            throw new NotFoundException();
        }

        return command;
    }

    /// <summary>
    /// Update one Command
    /// </summary>
    public async Task UpdateCommand(CommandWhereUniqueInput uniqueId, CommandUpdateInput updateDto)
    {
        var command = updateDto.ToModel(uniqueId);

        _context.Entry(command).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Commands.Any(e => e.Id == command.Id))
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
