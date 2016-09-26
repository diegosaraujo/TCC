using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Domain.Interfaces.Repository
{
    public interface ILivroRepository : IRepository<Livro>
    {
        Livro ObterPorTitulo(string titulo);
        Livro ObterPorAutor(string autor);
        Livro ObterPorDisciplina(string disciplina);
        Livro ObterPorAnoLetivo(string anoLetivo);
    }
}