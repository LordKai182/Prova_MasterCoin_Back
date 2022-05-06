using MediatR;

namespace Domain.Commands.Conversor
{
    public class ConverterRealDolarRequest : IRequest<Response>
    {
        public double Valor { get; set; }
    }
}
