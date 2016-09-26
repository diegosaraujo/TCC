using DomainValidation.Validation;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repository;
using ProjetoDDD.Domain.Specifications.Clientes;

namespace ProjetoDDD.Domain.Validations.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var emailDuplicado = new ClienteDevePossuirEmailUnicoSpecification(clienteRepository);
            var clienteLivro = new ClienteDeveTerUmLivroSpecification();

            base.Add("emailDuplicado", new Rule<Cliente>(emailDuplicado, "E-mail já cadastrado! Esqueceu sua senha?"));
            base.Add("clienteLivro", new Rule<Cliente>(clienteLivro, "Cliente não informou endereço"));
        }
    }
}