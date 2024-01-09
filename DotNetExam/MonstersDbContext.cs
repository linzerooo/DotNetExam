using Microsoft.EntityFrameworkCore;
using Models;

public class MonstersDbContext : DbContext
{
    public MonstersDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Monster> Monsters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var raven = new Monster()
        {
            Id = 1,
            Name = "Raven",
            HitPoints = 50,
            AttackModifier = 10,
            AttackPerRound = 2,
            Damage = "1d6",
            DamageModifier = 3,
            ArmorClass = 12
        };

        var awakenedShrub = new Monster()
        {
            Id = 2,
            Name = "AwakenedShrub",
            HitPoints = 10,
            AttackModifier = 10,
            AttackPerRound = 1,
            Damage = "2d8",
            DamageModifier = 1,
            ArmorClass = 9
        };
        var kraken = new Monster()
        {
            Id = 3,
            Name = "Kraken",
            HitPoints = 472,
            AttackModifier = 10,
            AttackPerRound = 1,
            Damage = "27d20",
            DamageModifier = 1,
            ArmorClass = 18
        };

        modelBuilder.Entity<Monster>().HasData(raven, awakenedShrub, kraken);
    }
}