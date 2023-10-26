using JEOBWebAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace JEOBWebAPI.Models.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext>options): base(options) { }

        public DbSet<AlumnoViewModel> alumno { get; set; }  
        public DbSet<MateriasViewModel> materias { get; set; }  
    }
}
