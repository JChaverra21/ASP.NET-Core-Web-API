using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LeerData
{
    // Clase encargada de la conexión a la base de datos
    public class AppVentaCursosContext : DbContext
    {
        private const string connnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=RestApiNET;Integrated Security=True;TrustServerCertificate=True";

        // Constructor que recibe las opciones de configuración
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connnectionString);
        }

        // Método que se encarga de configurar las relaciones entre las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CursoInstructor>().HasKey(ci => new { ci.CursoId, ci.InstructorId });
        }

        // Propiedad que representa la tabla de curso en la base de datos
        public DbSet<Curso> Curso { get; set; }

        // Propiedad que representa la tabla de precio en la base de datos
        public DbSet<Precio> Precio { get; set; }

        // Propiedad que representa la tabla de Comentario en la base de datos
        public DbSet<Comentario> Comentario { get; set; }

        // Propiedad que representa la tabla de CursoInstructor en la base de datos
        public DbSet<CursoInstructor> CursoInstructor { get; set; }

        // Propiedad que representa la tabla de Instructor en la base de datos
        public DbSet<Instructor> Instructor { get; set; }
    }
}