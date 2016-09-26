using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repository;
using ProjetoDDD.Infra.Data.Context;

namespace ProjetoDDD.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ProjetoDDDContext context)
            : base(context)
        {

        }

        public Cliente ObterPorCidade(string cidade)
        {
            //return Db.Clientes.FirstOrDefault(c => c.Cidade == cidade);
            return Buscar(c => c.Cidade == cidade).FirstOrDefault();
        }

        public Cliente ObterPorBairro(string bairro)
        {
            return Buscar(c => c.Bairro == bairro).FirstOrDefault();
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Clientes";

            return cn.Query<Cliente>(sql);
        }

        public override Cliente ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Clientes c " +
                       "LEFT JOIN Livros e " +
                       "ON c.ClienteId = e.ClienteId " +
                       "WHERE c.ClienteId = @sid";

            var cliente = new List<Cliente>();
            cn.Query<Cliente, Livro, Cliente>(sql,
                (c, e) =>
                {
                    cliente.Add(c);
                    if (e != null)
                        cliente[0].Livros.Add(e);

                    return cliente.FirstOrDefault();
                }, new { sid = id }, splitOn: "ClienteId, LivroId");

            return cliente.FirstOrDefault();
        }
    }
}