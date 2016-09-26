using System;
using System.Collections.Generic;

namespace ProjetoDDD.Application
{
    public interface ICrudAppService<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity obj);
        void Remover(Guid id);
    }
}
