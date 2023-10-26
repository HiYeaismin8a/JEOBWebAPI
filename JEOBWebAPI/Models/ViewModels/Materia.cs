using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JEOBWebAPI.Models.ViewModels
{
    [Table("Materias")]
    public class Materia
    {
        [Required]
        [Key]
        public int IdMateria { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public decimal Costo { get; set; }

        public List<Alumno> Alumnos { get; } = new ();
    }
}
