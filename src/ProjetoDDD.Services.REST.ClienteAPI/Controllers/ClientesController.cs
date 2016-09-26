using System;
using System.Collections.Generic;
using System.Web.Http;
using ProjetoDDD.Application.Interfaces;
using ProjetoModelo_MVC.ViewModels;
using ProjetoDDD.Application.ViewModels;

namespace ProjetoDDD.Services.REST.ClienteAPI.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<ClienteViewModel> ListarTodos()
        {
            return _clienteAppService.ObterTodos();
        }

        // GET: api/Clientes/5
        public ClienteViewModel Get(Guid id)
        {
            return _clienteAppService.ObterPorId(id);
        }

        // POST: api/Clientes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clientes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clientes/5
        public void Delete(int id)
        {
        }
    }
}
