using System;
using System.Collections.Generic;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repository;
using ProjetoDDD.Domain.Interfaces.Service;
using ProjetoDDD.Domain.Validations.Clientes;

namespace ProjetoDDD.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ILivroRepository _livroRepository;

        public ClienteService(IClienteRepository clienteRepository, ILivroRepository livroRepository)
        {
            _clienteRepository = clienteRepository;
            _livroRepository = livroRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.IsValid())
            {
                return cliente;
            }

            cliente.ValidationResult = new ClienteAptoParaCadastroValidation(_clienteRepository).Validate(cliente);
            if (!cliente.ValidationResult.IsValid)
            {
                return cliente;
            }

            cliente.ValidationResult.Message = "Cliente cadastrado com sucesso :)";
            return _clienteRepository.Adicionar(cliente);
        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public Cliente ObterPorCidade(string cidade)
        {
            return _clienteRepository.ObterPorCidade(cidade);
        }

        public Cliente ObterPorBairro(string bairro)
        {
            return _clienteRepository.ObterPorBairro(bairro);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return _clienteRepository.Atualizar(cliente);
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public Livro AdicionarLivro(Livro livro)
        {
            return _livroRepository.Adicionar(livro);
        }

        public Livro AtualizarLivro(Livro Livro)
        {
            return _livroRepository.Atualizar(Livro);
        }

        public Livro ObterLivroPorId(Guid id)
        {
            return _livroRepository.ObterPorId(id);
        }

        public void RemoverLivro(Guid id)
        {
            _livroRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}