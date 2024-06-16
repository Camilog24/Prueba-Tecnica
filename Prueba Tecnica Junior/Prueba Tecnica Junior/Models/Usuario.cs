using System.ComponentModel.DataAnnotations;

namespace Prueba_Tecnica_Junior.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        [MaxLength(70)]
        public string Usuarios { get; set; }
        [Required]
        [MaxLength(70)]
        public string Contraseña { get; set; }
        [Required]
        [MaxLength(20)]
        public DateTime Fecha_Creacion { get; set; }
    }
}
