using System.Linq;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repository;
using ProjetoDDD.Infra.Data.Context;

namespace ProjetoDDD.Infra.Data.Repository
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(ProjetoDDDContext context)
            : base(context)
        {

        }

        public Livro ObterPorAnoLetivo(string anoLetivo)
        {
            return Buscar(a => a.AnoLetivo == anoLetivo).FirstOrDefault();
        }

        public Livro ObterPorAutor(string autor)
        {
            return Buscar(c => c.Autor == autor).FirstOrDefault();
        }

        public Livro ObterPorDisciplina(string disciplina)
        {
            return Buscar(c => c.Disciplina == disciplina).FirstOrDefault();
        }

        public Livro ObterPorTitulo(string titulo)
        {
            return Buscar(c => c.Titulo == titulo).FirstOrDefault();
        }
    }
}