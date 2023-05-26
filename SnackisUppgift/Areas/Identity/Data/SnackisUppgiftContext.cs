using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnackisUppgift.Areas.Identity.Data;
using SnackisUppgift.Models;

namespace SnackisUppgift.Data;

public class SnackisUppgiftContext : IdentityDbContext<SnackisUppgiftUser>
{
    public SnackisUppgiftContext(DbContextOptions<SnackisUppgiftContext> options)
        : base(options)
    {
    }
    public DbSet<DirectMessage> DirectMessages { get; set; } = default!;
    public DbSet<SnackisUppgift.Models.Post> Post { get; set; } = default!;
    public DbSet<SnackisUppgift.Models.Subject> Subjects { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // For SenderId foreign key
        modelBuilder.Entity<DirectMessage>()
            .HasOne(dm => dm.Sender)
            .WithMany(u => u.MessagesSent)
            .HasForeignKey(dm => dm.SenderId)
            .OnDelete(DeleteBehavior.Restrict);  // This prevents cascade delete

        // For ReceiverId foreign key
        modelBuilder.Entity<DirectMessage>()
            .HasOne(dm => dm.Receiver)
            .WithMany(u => u.MessagesReceived)
            .HasForeignKey(dm => dm.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);  // This prevents cascade delete

        // Mapping Subject to the "Subjects" table
        modelBuilder.Entity<SnackisUppgift.Models.Subject>().ToTable("Subjects");
    }
}
