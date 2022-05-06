using MediatR;

namespace Domain.Commands.Usuario.Adicionar
{
    public class AdicionarUsuarioResquest :  IRequest<Response>
    {
        public Entities.Entity.Usuario Usuario { get; set; }
    }
}

