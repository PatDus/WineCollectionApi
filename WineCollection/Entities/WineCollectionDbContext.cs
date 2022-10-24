using Microsoft.EntityFrameworkCore;

namespace WineCollection.Entities
{
    public class WineCollectionDbContext : DbContext
    {
        public WineCollectionDbContext(DbContextOptions<WineCollectionDbContext> options) : base(options) { }


        public DbSet<Wine> Wines { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<GrapeVariety> GrapeVarieties { get; set; }
        public DbSet<Vineyard> Vineyards { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<WineCellar> WineCellars { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Wine>(eb =>
            {
                eb.Property(w => w.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                eb.Property(w => w.Description)
                    .HasMaxLength(500);

                eb.Property(w => w.TasteDescription)
                    .HasMaxLength(500);

                eb.Property(w => w.Price)
                    .HasColumnType("decimal(8,2)");

                eb.Property(w => w.Style)
                    .HasMaxLength(200);


                eb.Property(w => w.ServingTemperature)
                    .HasColumnName("ServingTemp_(C)")
                    .HasColumnType("decimal(3,1)")
                    .HasMaxLength(20);


                eb.HasOne(w => w.Color)
                   .WithMany(c => c.Wines)
                   .HasForeignKey(w => w.ColorId);

                eb.HasOne(w => w.GrapeVariety)
                   .WithMany(gv => gv.Wines)
                   .HasForeignKey(w => w.GrapeVarietyId);

                eb.HasOne(w => w.Vineyard)
                   .WithMany(v => v.Wines)
                   .HasForeignKey(w => w.VineyardId);

                eb.HasOne(w => w.WineCellar)
                   .WithMany(c => c.Wines)
                   .HasForeignKey(w => w.WineCellarId)
                   .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Color>(eb =>
            {
                eb.Property(c => c.ColorName)
                .HasColumnName("Color")
                .IsRequired()
                .HasMaxLength(5);
                eb.HasData(
                    new Color() { Id = 1, ColorName = "Red" },
                    new Color() { Id = 2, ColorName = "White" },
                    new Color() { Id = 3, ColorName = "Rose" }
                    );
            });


            modelBuilder.Entity<Country>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<GrapeVariety>(eb =>
            {
                eb.Property(gv => gv.GrapeVarietyName)
                  .HasColumnName("GrapeVarietyName")
                  .HasDefaultValue("unknown");

                eb.Property(gv => gv.Description)
                  .HasMaxLength(500);
            });

            modelBuilder.Entity<Vineyard>(eb =>
            {
                eb.Property(v => v.Name)
                  .HasMaxLength(50);

                eb.Property(v => v.Region)
                  .HasMaxLength(25);


                eb.HasOne(v => v.Country)
                  .WithMany(c => c.Vineyards)
                  .HasForeignKey(v => v.CountryId);
            });

            modelBuilder.Entity<User>(eb =>
            {
                eb.Property(u => u.Email)
                    .IsRequired();

                eb.Property(u => u.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                eb.Property(u => u.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                eb.Property(u => u.PasswordHash)
                    .IsRequired();


                eb.HasMany(u => u.WineCellars)
                  .WithOne(wc => wc.User)
                  .HasForeignKey(wc => wc.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

                eb.HasMany(u => u.Wines)
                  .WithOne(w => w.User)
                  .HasForeignKey(w => w.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
