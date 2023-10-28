using JEOBWebAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace JEOBWebAPI.Models.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Materia> Materias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Alumno>().Property(x => x.Materias).IsRequired(false);
        }
    }

    
}
