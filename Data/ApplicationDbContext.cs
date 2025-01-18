using GameZone.Models;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<GameDevice> GameDevics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Name="Cat1",Description="descption"},
                new Category { Id = 2, Name = "Cat2", Description = "descption" },
                new Category { Id = 3, Name = "Cat3", Description = "descption" }); 
            modelBuilder.Entity<GameDevice>()
                    .HasOne(gd => gd.Game) 
                    .WithMany(g => g.GameDevices) 
                    .HasForeignKey(gd => gd.DeviceId)
                    .HasForeignKey(game=>game.GameId);
            modelBuilder.Entity<Device>().HasData(
               new Device { Id = 1, Name = "dev1", Icon ="icon1" },
               new Device { Id = 2, Name = "dev2", Icon = "icon1" },
               new Device { Id = 3, Name = "dev3", Icon = "icon1" });
            modelBuilder.Entity<GameDevice>().HasKey(pk => new { pk.DeviceId, pk.GameId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
