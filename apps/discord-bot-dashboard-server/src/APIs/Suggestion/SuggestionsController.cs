using Microsoft.AspNetCore.Mvc;

namespace DiscordBotDashboard.APIs;

[ApiController()]
public class SuggestionsController : SuggestionsControllerBase
{
    public SuggestionsController(ISuggestionsService service)
        : base(service) { }
}
