using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBotDashboard.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class CommandFindManyArgs : FindManyInput<Command, CommandWhereInput> { }
