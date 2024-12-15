using Microsoft.AspNetCore.Mvc;

namespace DiscordBotDashboard.APIs;

[ApiController()]
public class BotTokensController : BotTokensControllerBase
{
    public BotTokensController(IBotTokensService service)
        : base(service) { }
}
