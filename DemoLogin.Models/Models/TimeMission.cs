using System;
using System.Collections.Generic;

namespace DemoLogin.Models.Models;

public partial class TimeMission
{
    public long TimeMissionId { get; set; }

    public long MissionId { get; set; }

    public int? TotalSeat { get; set; }

    public DateTime? Deadline { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Mission Mission { get; set; } = null!;
}
