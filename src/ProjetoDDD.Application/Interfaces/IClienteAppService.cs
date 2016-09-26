using System;
using System.Collections.Generic;
using ProjetoDDD.Application.ViewModels;
using ProjetoModelo_MVC.ViewModels;

namespace ProjetoDDD.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteLivroViewModel Adicionar(ClienteLivroViewModel clienteLivroViewModel);
        ClienteViewModel ObterPorId(Guid id);
        ClienteViewModel ObterPorCidade(string cidade);
        ClienteViewModel ObterPorBairro(string bairro);
        IEnumerable<ClienteViewModel> ObterTodos();
        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);
        void Remover(Guid id);

        LivroViewModel AdicionarLivro(LivroViewModel LivroViewModel);
        LivroViewModel AtualizarLivro(LivroViewModel LivroViewModel);
        LivroViewModel ObterLivroPorId(Guid id);
        void RemoverLivro(Guid id);
    }
}