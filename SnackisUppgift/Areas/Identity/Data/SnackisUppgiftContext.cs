using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnackisUppgift.Areas.Identity.Data;

namespace SnackisUppgift.Data;

public class SnackisUppgiftContext : IdentityDbContext<SnackisUppgiftUser>
{
    public SnackisUppgiftContext(DbContextOptions<SnackisUppgiftContext> options)
        : base(options)
    {
    }

    public DbSet<SnackisUppgift.Models.Post> Post { get; set; } = default!;
    public DbSet<SnackisUppgift.Models.Subject> Subject { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
