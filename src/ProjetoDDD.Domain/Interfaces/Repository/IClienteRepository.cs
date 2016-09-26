using ProjetoDDD.Domain.Entities;


namespace ProjetoDDD.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorCidade(string cidade);
        Cliente ObterPorBairro(string bairro);
    }
}