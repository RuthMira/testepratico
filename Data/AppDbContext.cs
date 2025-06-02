using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Equipe> Equipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>()
            .HasOne(f => f.Equipe)
            .WithMany(e => e.Funcionarios)
            .HasForeignKey(f => f.EquipeId);

        modelBuilder.Entity<Funcionario>()
            .Property(f => f.Email)
            .IsRequired(false);
    }
}
