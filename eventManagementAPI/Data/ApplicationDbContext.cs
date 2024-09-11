using eventManagementAPI.Models;
using eventManagementAPI.Seeders;
using Microsoft.EntityFrameworkCore;
namespace eventManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<Token> Tokens { get; set; }


        // Configuración del modelo a nivel de entidad y relaciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tabla users
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(e => e.id).HasColumnName("pk_users");
                entity.Property(e => e.username).HasColumnName("username");
                entity.Property(e => e.lastname).HasColumnName("lastname");
                entity.Property(e => e.cellphone).HasColumnName("cellphone");
                entity.Property(e => e.email).HasColumnName("email");
                entity.Property(e => e.password).HasColumnName("password");
                entity.Property(e => e.userTypeId).HasColumnName("fk_user_types");
            });

            // Tabla user_types
            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("user_types");
                entity.Property(e => e.id).HasColumnName("pk_user_types");
                entity.Property(e => e.name).HasColumnName("user_type_name");
                entity.Property(e => e.description).HasColumnName("user_type_description");
            });

            // Tabla tokens
            modelBuilder.Entity<Token>(entity =>
            {
                entity.ToTable("tokens");
                entity.Property(e => e.id).HasColumnName("pk_tokens");
                entity.Property(e => e.jwtToken).HasColumnName("jwt_token");
                entity.Property(e => e.expiration).HasColumnName("expiration");
                entity.Property(e => e.isRevoked).HasColumnName("is_revoked");
                entity.Property(e => e.userId).HasColumnName("fk_users");
            });

            // Tabla provinces
            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Provinces");
                entity.Property(e => e.id).HasColumnName("pk_provinces");
                entity.Property(e => e.name).HasColumnName("province_name");
            });

            // Tabla cantons
            modelBuilder.Entity<Canton>(entity =>
            {
                entity.ToTable("Cantons");
                entity.Property(e => e.id).HasColumnName("pk_cantons");
                entity.Property(e => e.name).HasColumnName("canton_name");
                entity.Property(e => e.provinceId).HasColumnName("fk_provinces");
            });

            // Tabla districts
            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("Districts");
                entity.Property(e => e.id).HasColumnName("pk_districts");
                entity.Property(e => e.name).HasColumnName("district_name");
                entity.Property(e => e.cantonId).HasColumnName("fk_cantons");
            });

            // Tabla events
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Events");
                //detalles basicos
                entity.Property(e => e.id).HasColumnName("pk_events");
                entity.Property(e => e.name).HasColumnName("event_name");
                entity.Property(e => e.description).HasColumnName("event_description");
                entity.Property(e => e.details).HasColumnName("event_details");
                entity.Property(e => e.description).HasColumnName("event_description");

                //detalles lugar
                entity.Property(e => e.exactPlace).HasColumnName("exact_place");
                entity.Property(e => e.provinceId).HasColumnName("fk_provinces");
                entity.Property(e => e.cantonId).HasColumnName("fk_cantons");
                entity.Property(e => e.districtId).HasColumnName("fk_districts");

                //detalles de hora y dia
                entity.Property(e => e.startingTime).HasColumnName("starting_time");
                entity.Property(e => e.finishingTime).HasColumnName("finishing_time");
                entity.Property(e => e.startDate).HasColumnName("start_date");
                entity.Property(e => e.endDate).HasColumnName("end_date");

                // Relación con la tabla Provinces (sin eliminación en cascada)
                entity.HasOne(e => e.province)
                      .WithMany(p => p.events)
                      .HasForeignKey(e => e.provinceId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relación con la tabla Cantons (sin eliminación en cascada)
                entity.HasOne(e => e.canton)
                      .WithMany(c => c.events)
                      .HasForeignKey(e => e.cantonId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relación con la tabla Districts (sin eliminación en cascada)
                entity.HasOne(e => e.district)
                      .WithMany(d => d.events)
                      .HasForeignKey(e => e.districtId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            //Seeders
            UserTypeSeeder.Seed(modelBuilder);
            UserSeeder.Seed(modelBuilder, 50);
        }
    }
}
