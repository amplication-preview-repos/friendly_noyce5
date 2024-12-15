using DiscordBotDashboard.APIs;
using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.APIs.Errors;
using DiscordBotDashboard.APIs.Extensions;
using DiscordBotDashboard.Infrastructure;
using DiscordBotDashboard.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotDashboard.APIs;

public abstract class BotTokensServiceBase : IBotTokensService
{
    protected readonly DiscordBotDashboardDbContext _context;

    public BotTokensServiceBase(DiscordBotDashboardDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one BotToken
    /// </summary>
    public async Task<BotToken> CreateBotToken(BotTokenCreateInput createDto)
    {
        var botToken = new BotTokenDbModel
        {
            CreatedAt = createDto.CreatedAt,
            CreatedDate = createDto.CreatedDate,
            Token = createDto.Token,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            botToken.Id = createDto.Id;
        }

        _context.BotTokens.Add(botToken);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<BotTokenDbModel>(botToken.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one BotToken
    /// </summary>
    public async Task DeleteBotToken(BotTokenWhereUniqueInput uniqueId)
    {
        var botToken = await _context.BotTokens.FindAsync(uniqueId.Id);
        if (botToken == null)
        {
            throw new NotFoundException();
        }

        _context.BotTokens.Remove(botToken);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many BotTokens
    /// </summary>
    public async Task<List<BotToken>> BotTokens(BotTokenFindManyArgs findManyArgs)
    {
        var botTokens = await _context
            .BotTokens.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return botTokens.ConvertAll(botToken => botToken.ToDto());
    }

    /// <summary>
    /// Meta data about BotToken records
    /// </summary>
    public async Task<MetadataDto> BotTokensMeta(BotTokenFindManyArgs findManyArgs)
    {
        var count = await _context.BotTokens.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one BotToken
    /// </summary>
    public async Task<BotToken> BotToken(BotTokenWhereUniqueInput uniqueId)
    {
        var botTokens = await this.BotTokens(
            new BotTokenFindManyArgs { Where = new BotTokenWhereInput { Id = uniqueId.Id } }
        );
        var botToken = botTokens.FirstOrDefault();
        if (botToken == null)
        {
            throw new NotFoundException();
        }

        return botToken;
    }

    /// <summary>
    /// Update one BotToken
    /// </summary>
    public async Task UpdateBotToken(
        BotTokenWhereUniqueInput uniqueId,
        BotTokenUpdateInput updateDto
    )
    {
        var botToken = updateDto.ToModel(uniqueId);

        _context.Entry(botToken).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.BotTokens.Any(e => e.Id == botToken.Id))
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
