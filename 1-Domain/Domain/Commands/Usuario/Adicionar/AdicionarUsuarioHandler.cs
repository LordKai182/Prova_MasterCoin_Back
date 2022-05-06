using Domain.Interfaces;
using MediatR;
using prmToolkit.NotificationPattern;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Usuario.Adicionar
{
    public class AdicionarUsuarioHandler : Notifiable, IRequestHandler<AdicionarUsuarioResquest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AdicionarUsuarioHandler(IMediator mediator, IRepositoryUsuario repositoryUsuario)
        {
            _mediator = mediator;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Response> Handle(AdicionarUsuarioResquest request, CancellationToken cancellationToken)
        {
            if (_repositoryUsuario.ListarPor(d => d.Email == request.Usuario.Email).ToList().Count() > 0)
            {
                AddNotification("Usuario", "Ja existe um usuario com este E-mail");
            }
            if (_repositoryUsuario.ListarPor(d => d.Nome == request.Usuario.Nome).ToList().Count() > 0)
            {
                AddNotification("Usuario", "Ja existe um usuario com este Nome");
            }

            AddNotifications(request.Usuario);

            if (IsInvalid())
            {
                return new Response(this);
            }


            var atividade = _repositoryUsuario.Adicionar(request.Usuario);

            var response = new Response(this, atividade);

            return await Task.FromResult(response);
        }
    }
}
