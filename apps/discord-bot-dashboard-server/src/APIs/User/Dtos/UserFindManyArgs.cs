using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBotDashboard.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class UserFindManyArgs : FindManyInput<User, UserWhereInput> { }
