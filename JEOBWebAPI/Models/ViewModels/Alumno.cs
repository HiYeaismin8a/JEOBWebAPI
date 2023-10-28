using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace JEOBWebAPI.Models.ViewModels
{
    [Table("Alumnos")]
    public class Alumno
    {
        [Required]
        [Key]
        public int IdAlumno { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string ApellidoPaterno { get; set; }

        [Required]
        public string ApellidoMaterno{ get; set; }

        [JsonIgnore]
        public List<Materia> Materias { get; set; } = new();
    }
}
