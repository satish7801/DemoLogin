using System;
using System.Collections.Generic;

namespace DemoLogin.Models.Models;

public partial class PasswordReset
{
    public long PasswordResetId { get; set; }

    public string Email { get; set; } = null!;

    public string Token { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
