using System.Linq;
using DomainValidation.Interfaces.Specification;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Domain.Specifications.Clientes
{
    public class ClienteDeveTerUmLivroSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return cliente.Livros != null && cliente.Livros.Any();
        }
    }
}