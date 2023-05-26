﻿using System;
using System.Collections.Generic;

namespace DemoLogin.Models.Models;

public partial class MissionRating
{
    public int MissionRatingId { get; set; }

    public long UserId { get; set; }

    public long MissionId { get; set; }

    public int Rating { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Mission Mission { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}