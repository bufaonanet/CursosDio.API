using curso.api.Business.Entities;

namespace curso.api.Business.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        Usuario ObterUsuario(string login);        
        void Commit();
    }
}
