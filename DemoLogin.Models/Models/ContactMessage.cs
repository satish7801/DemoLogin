using System;
using System.Collections.Generic;

namespace DemoLogin.Models.Models;

public partial class ContactMessage
{
    public long ContactMessageId { get; set; }

    public long UserId { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
