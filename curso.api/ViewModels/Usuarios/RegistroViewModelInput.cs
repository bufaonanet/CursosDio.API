using System.ComponentModel.DataAnnotations;

namespace curso.api.Models.Usuarios
{
    public class RegistroViewModelInput
    {
        [Required(ErrorMessage = "Campo '{0}' é obrigatório")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Campo '{0}' é obrigatório")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Campo '{0}' é obrigatório")]
        public string Senha { get; set; }
    }
}
