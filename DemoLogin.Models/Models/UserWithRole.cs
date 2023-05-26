using System;
using System.Collections.Generic;

namespace DemoLogin.Models.Models;

public partial class UserWithRole
{
    public long UserId { get; set; }

    public string? UserName { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? Role { get; set; }
}
