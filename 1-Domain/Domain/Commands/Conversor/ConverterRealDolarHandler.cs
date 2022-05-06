using Domain.Entities.Entity;
using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Conversor
{
    public class ConverterRealDolarHandler : Notifiable, IRequestHandler<ConverterRealDolarRequest, Response>
    {
        private readonly IMediator _mediator;

        public ConverterRealDolarHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Response> Handle(ConverterRealDolarRequest request, CancellationToken cancellationToken)
        {
          

            if (IsInvalid())
            {
                return new Response(this);
            }

            var cotacao = new Cotacao((float)request.Valor);
            var response = new Response(this, cotacao);

            return await Task.FromResult(response);
        }
    }
}
