using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace JEOBWebAPI.Models.ViewModels
{
    public class AlumnoViewModel
    {
        [Required]
        [Key]
        public int idAlumno { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string apellidoPaterno { get; set; }

        [Required]
        public string apellidoMaterno{ get; set; }
    }
}
