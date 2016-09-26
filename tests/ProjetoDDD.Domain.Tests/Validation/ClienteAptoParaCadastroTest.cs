using System.Linq;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repository;
using ProjetoDDD.Domain.Validations.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace ProjetoDDD.Domain.Tests.Validation
{
    [TestClass]
    public class ClienteAptoParaCadastroTest
    {
        public Cliente Cliente { get; set; }

        [TestMethod]
        public void ClienteApto_Validation_True()
        {
            Cliente = new Cliente()
            {
                Nome = "Diego Paquetá",
                Email = "paqueta@edu.com.br"
            };

            Cliente.Livros.Add(new Livro());

            var stubRepo = MockRepository.GenerateStub<IClienteRepository>();
            stubRepo.Stub(s => s.ObterPorCidade(Cliente.Cidade)).Return(null);
            stubRepo.Stub(s => s.ObterPorBairro(Cliente.Bairro)).Return(null);

            var cliValidation = new ClienteAptoParaCadastroValidation(stubRepo);
            Assert.IsTrue(cliValidation.Validate(Cliente).IsValid);
        }

        [TestMethod]
        public void ClienteApto_Validation_False()
        {
            Cliente = new Cliente()
            {
                Nome = "José Pivotto",
                Email = "pivotto@edu.com.br"
            };

            var stubRepo = MockRepository.GenerateStub<IClienteRepository>();
            stubRepo.Stub(s => s.ObterPorCidade(Cliente.Cidade)).Return(Cliente);
            stubRepo.Stub(s => s.ObterPorBairro(Cliente.Bairro)).Return(Cliente);

            var cliValidation = new ClienteAptoParaCadastroValidation(stubRepo);
            var result = cliValidation.Validate(Cliente);

            Assert.IsFalse(cliValidation.Validate(Cliente).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "E-mail já cadastrado! Esqueceu sua senha?"));
        }
    }
}
