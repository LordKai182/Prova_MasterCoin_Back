using Domain.Commands.Usuario.Adicionar;
using Domain.Commands.Usuario.Listar;
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
    
    public class UsuarioController : Base.ControllerBase
    {
        private readonly IMediator _mediator;



        public UsuarioController(IMediator mediator, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
        }



        /// <summary>
        /// Cadastra e verifica entradas na entidade de cliente
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("mc/Usuario/CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] AdicionarUsuarioResquest request)
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

        /// <summary>
        /// Listar Usuarios esta em post opis tem a possibilidade de PIPEAR A LISTA NUMA OCASIAO DE PAGINACAO POR EXEMPLO
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("mc/Usuario/ListarUsuario")]
        public async Task<IActionResult> ListarUsuario([FromBody] ListarUsuariosRequest request)
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
