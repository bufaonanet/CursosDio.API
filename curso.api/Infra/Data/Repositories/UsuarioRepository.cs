using curso.api.Business.Entities;
using curso.api.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CursoDbContext _context;

        public UsuarioRepository(CursoDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Usuario ObterUsuario(string login)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Login == login);
        }
    }
}
