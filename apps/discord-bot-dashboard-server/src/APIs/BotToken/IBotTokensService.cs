using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.APIs.Dtos;

namespace DiscordBotDashboard.APIs;

public interface IBotTokensService
{
    /// <summary>
    /// Create one BotToken
    /// </summary>
    public Task<BotToken> CreateBotToken(BotTokenCreateInput bottoken);

    /// <summary>
    /// Delete one BotToken
    /// </summary>
    public Task DeleteBotToken(BotTokenWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many BotTokens
    /// </summary>
    public Task<List<BotToken>> BotTokens(BotTokenFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about BotToken records
    /// </summary>
    public Task<MetadataDto> BotTokensMeta(BotTokenFindManyArgs findManyArgs);

    /// <summary>
    /// Get one BotToken
    /// </summary>
    public Task<BotToken> BotToken(BotTokenWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one BotToken
    /// </summary>
    public Task UpdateBotToken(BotTokenWhereUniqueInput uniqueId, BotTokenUpdateInput updateDto);
}
