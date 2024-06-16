using System.ComponentModel.DataAnnotations;

namespace Prueba_Tecnica_Junior.Models
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }
        [Required(ErrorMessage = "El campo Nombre Completo es obligatorio.")]
        [MaxLength(80)]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "el Campo Apellidos es obligatorio.")]
        [MaxLength(80)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo Tipo de identificación es obligatorio.")]
        public int TipoIdentificacion { get; set; }
        [Required(ErrorMessage = "El número de identificación es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El número de identificación debe contener solo dígitos.")]
        public int NoIdentificacion { get; set; }
        [Required(ErrorMessage = "El Campo Email es obligatorio.")]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El Campo Fecha de creacion es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }



    }
}
