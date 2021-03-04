using curso.api.Business.Entities;
using System.Collections.Generic;

namespace curso.api.Business.Repositories
{
    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        IList<Curso> ObterPorUsuario(int codigoUsuario);        
        void Commit();
    }
}
