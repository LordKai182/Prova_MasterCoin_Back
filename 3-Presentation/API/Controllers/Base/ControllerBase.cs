using Domain.Commands;
using Infra.Repositories.Base;
using Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Base
{
    public class ControllerBase : Controller
    {
        //ILog log = new Logger(Level.Info, @"C:/teste/CLIENTE_FICTICIO");

        private readonly IUnitOfWork _unitOfWork;
        private MasterCoinContext _context = new MasterCoinContext();

        public ControllerBase(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
            // log.Info($" Usuario : {User.FindFirst(d => d.Type == "Usuario").Value} Metodo: {Newtonsoft.Json.JsonConvert.SerializeObject(RouteData.Values)}");

        }

        public async void EntradaLogger(Object request)
        {
          
            // log.Info($" Usuario : {User.FindFirst(d => d.Type == "Usuario").Value},  Metodo: {Newtonsoft.Json.JsonConvert.SerializeObject(RouteData.Values)}, Entrada: {Newtonsoft.Json.JsonConvert.SerializeObject(request)}");
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<IActionResult> ResponseAsync(Response response)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            if (!response.Notifications.Any())
            {
                try
                {
                
                    _unitOfWork.SaveChanges();

                    return Ok(response);
                }
                catch (Exception ex)
                {

                    // Aqui devo logar o erro
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                    //return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {

                return Ok(response);
            }
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<IActionResult> ResponseExceptionAsync(Exception ex)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
          

            return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            //Realiza o dispose no serviço para que possa ser zerada as notificações
            //if (_serviceBase != null)
            //{
            //    _serviceBase.Dispose();
            //}

            base.Dispose(disposing);
        }


    }
}
