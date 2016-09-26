using System;

namespace ProjetoDDD.Domain.Entities
{
    public class Livro
    {
        public Livro()
        {
            LivroId = Guid.NewGuid();
        }

        public Guid LivroId { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string AnoLetivo { get; set; }
        public string Disciplina { get; set; }
        public bool Disponível { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}