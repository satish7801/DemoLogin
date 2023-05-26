using System;
using System.Collections.Generic;

namespace DemoLogin.Models.Models;

public partial class NotificationUser
{
    public long NotificationUserId { get; set; }

    public long? FromUserId { get; set; }

    public long? ToUserId { get; set; }

    public int NotificationType { get; set; }

    public bool? Status { get; set; }

    public long ComponentId { get; set; }

    public bool? IsRead { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
