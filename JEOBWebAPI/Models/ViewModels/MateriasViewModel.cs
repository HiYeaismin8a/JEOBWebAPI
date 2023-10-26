using System.ComponentModel.DataAnnotations;

namespace JEOBWebAPI.Models.ViewModels
{
    public class MateriasViewModel
    {
        [Required]
        [Key]
        public int idMateria { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public decimal costo { get; set; }

        
    }
}
