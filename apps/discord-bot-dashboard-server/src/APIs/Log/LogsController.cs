using Microsoft.AspNetCore.Mvc;

namespace DiscordBotDashboard.APIs;

[ApiController()]
public class LogsController : LogsControllerBase
{
    public LogsController(ILogsService service)
        : base(service) { }
}
