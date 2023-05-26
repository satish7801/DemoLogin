using DemoLogin.Identity;
using DemoLogin.Models.Data;
using DemoLogin.Repository.Interface;
using DemoLogin.Repository.Repository;
using DemoLogin.Service.ServiceInterface;
using DemoLogin.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args); 
builder.Services.AddDbContext<CiPlatformContext>(options => options.UseSqlServer(
     builder.Configuration.GetConnectionString("DefaultConnection")
     ));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey   = true
    };

    x.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            var token = context.Request.Cookies["token"]?.ToString(); //Store in httponly cookie
            if (token == null)
            {
                context.Response.Redirect("/Home/Login"); // Replace "/Home/Login" with your actual login page URL
                context.HandleResponse(); // Suppress the default challenge response
            }

            return Task.CompletedTask;
        }
    };

});

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy(IdentityData.AdminUserPolicyName, policy =>
        policy.RequireClaim(IdentityData.AdminUserClaimName, "true"));
});


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(BaseService<>));

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISkillService, SkillService>();

var app = builder.Build();

app.Use(async (context, next) => {
    var token = context.Request.Cookies["token"]?.ToString(); //Store in httponly cookie
    if (!string.IsNullOrWhiteSpace(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }
    await next();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
