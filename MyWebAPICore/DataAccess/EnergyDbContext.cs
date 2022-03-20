using Microsoft.EntityFrameworkCore;
using MyWebAPICore.DataAccess;

namespace MyWebAPICore
{
    public class EnergyDbContext : DbContext
    {

        public EnergyDbContext(DbContextOptions<EnergyDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts {get; set;}

        public DbSet<MeterReading> MeterReadings {get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Account>(entity =>
      {
        entity.HasKey(e => e.AccountId);
        entity.Property(e => e.FirstName).IsRequired();
        entity.Property(e=>e.LastName);
      });

      modelBuilder.Entity<MeterReading>(entity =>
      {
        entity.HasKey(e => e.MeterReadingId);
        entity.Property(e => e.AccountId).IsRequired();
        entity.Property(e=>e.MeterReadingDateTime).IsRequired();
        entity.Property(e=>e.MeterReadValue);
      });
    }
    }
}