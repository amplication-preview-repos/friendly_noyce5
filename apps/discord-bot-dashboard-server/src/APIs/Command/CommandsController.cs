using Microsoft.AspNetCore.Mvc;

namespace DiscordBotDashboard.APIs;

[ApiController()]
public class CommandsController : CommandsControllerBase
{
    public CommandsController(ICommandsService service)
        : base(service) { }
}
