using JEOBWebAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace JEOBWebAPI.Models.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }  
        public DbSet<Materia> Materias { get; set; }  
    }
}
