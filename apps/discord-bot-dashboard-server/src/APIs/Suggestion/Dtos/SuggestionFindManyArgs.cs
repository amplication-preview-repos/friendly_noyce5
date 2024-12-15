using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBotDashboard.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class SuggestionFindManyArgs : FindManyInput<Suggestion, SuggestionWhereInput> { }
