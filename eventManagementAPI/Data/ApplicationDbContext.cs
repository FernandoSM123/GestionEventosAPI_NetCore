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

            //Seeders
            UserTypeSeeder.Seed(modelBuilder);
            UserSeeder.Seed(modelBuilder, 50);
        }
    }
}
