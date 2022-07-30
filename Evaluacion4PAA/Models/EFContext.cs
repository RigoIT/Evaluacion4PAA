using Microsoft.EntityFrameworkCore;

namespace Evaluacion4PAA.Models
{
    public class EFContext : DbContext
    {
        // 1. Crear atributo que almacene la cadena de conexión a la BD
        private const string ConnectionString = "server=localhost;port=3306;database=sanremo_db;user=root;password=;Connect Timeout=5;";

        // para configurar la instancia inicial de MySQL en conexión al proyecto
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString,
                new MySqlServerVersion(new Version(8, 0, 11)));
        }

        // 2. Definir qué clases son modelos desde la base de datos
        public DbSet<Cantautor> Cantautor { get; set; }
        public DbSet<Cancion> Cancion { get; set; }

        // 3. Configurar los modelos 
        // * Definir clave primaria * Establecer las relaciones
        // * Definir cuáles son obligatorios * Cuál tiene valor por defecto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir claves primarias
            modelBuilder.Entity<Cancion>().HasKey(i => i.id_cancion);
            modelBuilder.Entity<Cantautor>().HasKey(j => j.id_cantautor);

            // Definir relaciones uno a muchos: Canción a Álbum
            modelBuilder.Entity<Cancion>()
                .HasOne<Cantautor>(s => s.Cantautor)
                .WithMany(g => g.Canciones)
                .HasForeignKey(c => c.id_cantautor);

            // Definimos los obligatorios (not null - mandatory) 
            // Canción:
            modelBuilder.Entity<Cancion>().Property(s => s.id_cantautor).IsRequired();
            modelBuilder.Entity<Cancion>().Property(s => s.nombre_cancion).IsRequired();
            modelBuilder.Entity<Cancion>().Property(s => s.posicion).IsRequired();

            // Álbum:
            modelBuilder.Entity<Cantautor>().Property(s => s.nombre_cantautor).IsRequired();
            modelBuilder.Entity<Cantautor>().Property(s => s.primera_presentacion)
                .HasDefaultValue(DateTime.Now) // Indicar un valor por defecto
                .IsRequired();
            modelBuilder.Entity<Cantautor>().Property(s => s.canciones_publicadas).IsRequired();
        }

    }
}
