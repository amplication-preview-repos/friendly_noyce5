using Microsoft.AspNetCore.Mvc;

namespace DiscordBotDashboard.APIs;

[ApiController()]
public class AnalyticsItemsController : AnalyticsItemsControllerBase
{
    public AnalyticsItemsController(IAnalyticsItemsService service)
        : base(service) { }
}
