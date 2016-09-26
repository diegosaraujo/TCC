using System;
using DomainValidation.Interfaces.Specification;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Domain.Specifications.Clientes
{
    public class ClienteDeveSerMaiorDeIdadeSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return DateTime.Now.Year - cliente.DataNascimento.Year >= 18;
        }
    }
}