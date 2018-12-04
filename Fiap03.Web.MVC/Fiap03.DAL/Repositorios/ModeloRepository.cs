using Dapper;
using Fiap03.DAL.Repositorios.Interfaces;
using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap03.DAL.Repositorios
{
    public class ModeloRepository : IModeloRepository
    {
        public IList<ModeloMOD> BuscarModelos(int marcaId)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = @"SELECT * FROM Modelo WHERE MarcaId = @MarcaId";

                return db.Query<ModeloMOD>(sql, new { MarcaId = marcaId }).ToList();
            }
        }

        public void Cadastrar(ModeloMOD modelo)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = "INSERT INTO Modelo VALUES (@Nome, @MarcaId)";

                db.Execute(sql, new { Nome = modelo.Nome, MarcaId = modelo.MarcaId });
            }
        }

        public IList<ModeloMOD> Listar(int marcaId)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = "SELECT * FROM Modelo WHERE MarcaId = @MarcaId";

                return db.Query<ModeloMOD>(sql, new { MarcaId = marcaId }).ToList();
            }
        }

        public bool Excluir(int id)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = "DELETE FROM Modelo WHERE Id = @Id";

                return db.Execute(sql, new { Id = id }) > 0;
            }
        }
    }
}
