using Domain.Commands.Conversor;
using Infra.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ConverterController : Base.ControllerBase
    {
        private readonly IMediator _mediator;



        public ConverterController(IMediator mediator, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("mc/Converter/ConverterParaDolar")]
        public async Task<IActionResult> ConverterParaDolar([FromBody] ConverterRealDolarRequest request)
        {

            try
            {

                var response = await _mediator.Send(request, CancellationToken.None);

                return await ResponseAsync(response);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.InnerException.Message);
            }
        }
    }
}
