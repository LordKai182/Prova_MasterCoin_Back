using Domain.Entities.Entity;
using Domain.Interfaces;
using Infra.Repositories.Base;
using System;

namespace Infra.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario, Guid>, IRepositoryUsuario
    {
        private readonly MasterCoinContext _context;

        public RepositoryUsuario(MasterCoinContext context) : base(context)
        {
            _context = context;
        }

        public Usuario AdicionarUsuario(Usuario usuario)
        {
            _context.Add(usuario);

            return usuario;
        }
    }
}
