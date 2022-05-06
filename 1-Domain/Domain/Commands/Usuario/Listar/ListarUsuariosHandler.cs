using Domain.Interfaces;
using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Usuario.Listar
{
    public class ListarUsuariosHandler : Notifiable, IRequestHandler<ListarUsuariosRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public ListarUsuariosHandler(IMediator mediator, IRepositoryUsuario repositoryUsuario)
        {
            _mediator = mediator;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Response> Handle(ListarUsuariosRequest request, CancellationToken cancellationToken)
        {
            
            if (IsInvalid())
            {
                return new Response(this);
            }

            return new Response(this, _repositoryUsuario.Listar());
        }
    }
}
