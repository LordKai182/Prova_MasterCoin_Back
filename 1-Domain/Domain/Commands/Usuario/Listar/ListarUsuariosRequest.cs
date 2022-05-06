using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands.Usuario.Listar
{
    public class ListarUsuariosRequest : IRequest<Response>
    {
        public int QuantidadeLista { get; set; }
    }
}
