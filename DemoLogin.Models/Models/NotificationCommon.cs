using System;
using System.Collections.Generic;

namespace DemoLogin.Models.Models;

public partial class NotificationCommon
{
    public long NotificationCommonId { get; set; }

    public string? Message { get; set; }

    public long MissionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Mission Mission { get; set; } = null!;

    public virtual ICollection<NotificationUserSeen> NotificationUserSeens { get; set; } = new List<NotificationUserSeen>();
}
