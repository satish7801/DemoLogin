using System;
using System.Collections.Generic;

namespace DemoLogin.Models.Models;

public partial class NotificationUserSeen
{
    public long NotificationUserSeenId { get; set; }

    public long NotificationCommonId { get; set; }

    public long UserId { get; set; }

    public bool? IsRead { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual NotificationCommon NotificationCommon { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
