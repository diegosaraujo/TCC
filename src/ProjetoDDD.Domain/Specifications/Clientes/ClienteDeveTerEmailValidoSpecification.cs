using DomainValidation.Interfaces.Specification;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Validations.Documentos;

namespace ProjetoDDD.Domain.Specifications.Clientes
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return EmailValidation.Validate(cliente.Email);
        }
    }
}