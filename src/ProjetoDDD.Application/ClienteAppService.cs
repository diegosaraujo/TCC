using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using AutoMapper;
using ProjetoDDD.Application.Interfaces;
using ProjetoDDD.Application.ViewModels;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Service;
using ProjetoDDD.Infra.Data.Interfaces;
using ProjetoModelo_MVC.ViewModels;

namespace ProjetoDDD.Application
{
    public class ClienteAppService : ApplicationService, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork uow)
            : base(uow)
        {
            _clienteService = clienteService;
        }

        public ClienteLivroViewModel Adicionar(ClienteLivroViewModel clienteLivroViewModel)
        {
            var cliente = Mapper.Map<ClienteLivroViewModel, Cliente>(clienteLivroViewModel);
            var Livro = Mapper.Map<ClienteLivroViewModel, Livro>(clienteLivroViewModel);

            cliente.Livros.Add(Livro);
            var foto = clienteLivroViewModel.Foto;

            BeginTransaction();

            var clienteReturn = _clienteService.Adicionar(cliente);
            clienteLivroViewModel = Mapper.Map<Cliente, ClienteLivroViewModel>(clienteReturn);
            if (!clienteReturn.ValidationResult.IsValid)
            {
                // Não faz o commit
                return clienteLivroViewModel;
            }

            if (!SalvarImagemCliente(foto, clienteLivroViewModel.ClienteId))
            {
                // Tomada de decisão caso a imagem não seja gravada.
                clienteLivroViewModel.ValidationResult.Message = "Cliente salvo sem foto";
            }

            Commit();

            return clienteLivroViewModel;
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorId(id));
        }

        public ClienteViewModel ObterPorCidade(string cidade)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorCidade(cidade));
        }

        public ClienteViewModel ObterPorBairro(string bairro)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorBairro(bairro));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteService.ObterTodos());
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            BeginTransaction();
            _clienteService.Atualizar(Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel));
            Commit();
            return clienteViewModel;
        }

        public void Remover(Guid id)
        {
            BeginTransaction();
            _clienteService.Remover(id);
            Commit();
        }

        public LivroViewModel AdicionarLivro(LivroViewModel LivroViewModel)
        {
            var Livro = Mapper.Map<LivroViewModel, Livro>(LivroViewModel);
            
            BeginTransaction();
            _clienteService.AdicionarLivro(Livro);
            Commit();

            return LivroViewModel;
        }

        public LivroViewModel AtualizarLivro(LivroViewModel LivroViewModel)
        {
            var Livro = Mapper.Map<LivroViewModel, Livro>(LivroViewModel);

            BeginTransaction();
            _clienteService.AtualizarLivro(Livro);
            Commit();

            return LivroViewModel;
        }

        public LivroViewModel ObterLivroPorId(Guid id)
        {
            return Mapper.Map<Livro, LivroViewModel>(_clienteService.ObterLivroPorId(id));
        }

        public void RemoverLivro(Guid id)
        {
            BeginTransaction();
            _clienteService.RemoverLivro(id);
            Commit();
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }

        private static bool SalvarImagemCliente(HttpPostedFileBase img, Guid id)
        {
            if (img == null || img.ContentLength <= 0) return false;

            const string directory = @"C:\TCC\Temp\clientes\";
            var fileName = id + Path.GetExtension(img.FileName);
            img.SaveAs(Path.Combine(directory, fileName));
            return File.Exists(Path.Combine(directory, fileName));
        }
    }
}