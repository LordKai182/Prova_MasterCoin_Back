using Domain.Entities.Entity;
using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario, Guid>
    {
        Usuario AdicionarUsuario(Usuario usuario); 
    }
}
