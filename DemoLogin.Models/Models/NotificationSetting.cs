using System;
using System.Collections.Generic;

namespace DemoLogin.Models.Models;

public partial class NotificationSetting
{
    public long NotificationSettingId { get; set; }

    public long UserId { get; set; }

    public bool? RecommendedMissions { get; set; }

    public bool? VolunteeringHours { get; set; }

    public bool? VolunteeringGoals { get; set; }

    public bool? MyComments { get; set; }

    public bool? MyStories { get; set; }

    public bool? NewMission { get; set; }

    public bool? NewMessages { get; set; }

    public bool? RecommendedStory { get; set; }

    public bool? MissionApplication { get; set; }

    public bool? News { get; set; }

    public bool? ReceiveNotificationByEmail { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
