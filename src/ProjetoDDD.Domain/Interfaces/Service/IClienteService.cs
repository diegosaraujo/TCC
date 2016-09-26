using System;
using System.Collections.Generic;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Domain.Interfaces.Service
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente ObterPorId(Guid id);
        Cliente ObterPorCidade(string cidade);
        Cliente ObterPorBairro(string bairro);
        IEnumerable<Cliente> ObterTodos();
        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id);

        Livro AdicionarLivro(Livro Livro);
        Livro AtualizarLivro(Livro Livro);
        Livro ObterLivroPorId(Guid id);
        
        void RemoverLivro(Guid id);
    }
}