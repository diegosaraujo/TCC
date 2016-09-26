using System;
using System.Collections.Generic;
using DomainValidation.Validation;
using ProjetoDDD.Domain.Validations.Clientes;

namespace ProjetoDDD.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
            Livros = new List<Livro>();
        }

        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }

        public bool IsValid()
        {
            ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}