using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoDDD.Application.Interfaces;
using ProjetoDDD.Application.ViewModels;
using ProjetoDDD.Infra.CrossCutting.MvcFilters;
using Microsoft.Ajax.Utilities;
using ProjetoModelo_MVC.ViewModels;

namespace ProjetoDDD.UI.Mvc.Controllers
{
    [RoutePrefix("administrativo-clientes")]
    [Route("{action=listar}")]
    public class ClientesController : Controller
    {
        private IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [Route("listar")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterTodos());
        }

        [Route("detalhes/{id:guid}")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("incluir-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("incluir-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteLivroViewModel clienteLivroViewModel)
        {
            if (ModelState.IsValid)
            {
                clienteLivroViewModel = _clienteAppService.Adicionar(clienteLivroViewModel);

                if (!clienteLivroViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in clienteLivroViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(clienteLivroViewModel);
                }


                if (!clienteLivroViewModel.ValidationResult.Message.IsNullOrWhiteSpace())
                {
                    ViewBag.Sucesso = clienteLivroViewModel.ValidationResult.Message;
                    return View(clienteLivroViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(clienteLivroViewModel);
        }

        [Route("editar/{id:guid}")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClienteId = id;
            return View(clienteViewModel);
        }

        [Route("editar/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("excluir/{id:guid}")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("excluir/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        public ActionResult ListarLivros(Guid id)
        {
            ViewBag.ClienteId = id;
            return PartialView("_LivrosList", _clienteAppService.ObterPorId(id).Livros);
        }

        [Route("adicionar-Livro")]
        public ActionResult AdicionarLivro(Guid id)
        {
            ViewBag.ClienteId = id;
            return PartialView("_AdicionarLivro");
        }

        [Route("adicionar-Livro")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarLivro(LivroViewModel LivroViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.AdicionarLivro(LivroViewModel);

                string url = Url.Action("ListarLivros", "Clientes", new { id = LivroViewModel.ClienteId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarLivro", LivroViewModel);
        }

        [Route("adicionar-Livro/{id:guid}")]
        public ActionResult AtualizarLivro(Guid id)
        {
            return PartialView("_AtualizarLivro", _clienteAppService.ObterLivroPorId(id));
        }

        [Route("adicionar-Livro/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarLivro(LivroViewModel LivroViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.AtualizarLivro(LivroViewModel);

                string url = Url.Action("ListarLivros", "Clientes", new { id = LivroViewModel.ClienteId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AtualizarLivro", LivroViewModel);
        }

        [Route("excluir-Livro/{id:guid}")]
        public ActionResult DeletarLivro(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var LivroViewModel = _clienteAppService.ObterLivroPorId(id.Value);
            if (LivroViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarLivro", LivroViewModel);
        }

        // POST: Clientes/Delete/5

        [Route("excluir-Livro/{id:guid}")]
        [HttpPost, ActionName("DeletarLivro")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarLivroConfirmed(Guid id)
        {
            var clienteId = _clienteAppService.ObterLivroPorId(id).ClienteId;
            _clienteAppService.RemoverLivro(id);

            string url = Url.Action("ListarLivros", "Clientes", new { id = clienteId });
            return Json(new { success = true, url = url });
        }

        public ActionResult ObterImagemCliente(Guid id)
        {
            var root = @"D:\Labs\CursoMVC Update\src\contents\clientes\";
            var foto = Directory.GetFiles(root, id+"*").FirstOrDefault();
           
            if (foto != null && !foto.StartsWith(root))
            {
                // Validando qualquer acesso indevido além da pasta permitida
                throw new HttpException(403, "Acesso Negado");
            }

            if(foto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return File(foto, "image/jpeg");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
