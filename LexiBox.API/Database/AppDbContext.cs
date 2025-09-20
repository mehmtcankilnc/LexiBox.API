using LexiBox.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LexiBox.API.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Vocabulary> Vocabularies => Set<Vocabulary>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vocabulary>()
            .Property(v => v.Category)
            .HasConversion<string>()
            .HasMaxLength(16);

        modelBuilder.Entity<Vocabulary>()
            .HasIndex(v => v.Word)
            .IsUnique();
    }
}
