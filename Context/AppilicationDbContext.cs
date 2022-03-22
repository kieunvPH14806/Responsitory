using Demo_Responsitory.Entities;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Demo_Responsitory;

public class AppilicationDbContext : DbContext
{
    public AppilicationDbContext(DbContextOptions<AppilicationDbContext> options): base(options)
    {
        
    }

    public virtual DbSet<Class> Classes { get; set; }
    public virtual  DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("CLASS");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd();

        });
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("STUDENT");
            entity.HasKey(p => p.Id);
            entity.HasMany<Class>(p => p.Classes)
                .WithMany(p => p.Students);
            entity.Property(c => c.Id).ValueGeneratedOnAdd();
        });
    }
}