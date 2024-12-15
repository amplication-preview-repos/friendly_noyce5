using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordBotDashboard.Infrastructure.Models;

[Table("BotTokens")]
public class BotTokenDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? CreatedDate { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Token { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
