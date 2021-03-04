using System.ComponentModel.DataAnnotations;

namespace curso.api.Models.Usuarios
{
    public class UsuarioViewModelOutPut
    {
        
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Campo '{0}' é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo '{0}' é obrigatório")]
        public string Email { get; set; }
    }
}
