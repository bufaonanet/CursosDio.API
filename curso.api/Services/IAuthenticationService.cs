using curso.api.Models.Usuarios;

namespace curso.api.Services
{
    public interface IAuthenticationService
    {
        string GerarToken(UsuarioViewModelOutPut usuarioViewModelOut);
    }
}
