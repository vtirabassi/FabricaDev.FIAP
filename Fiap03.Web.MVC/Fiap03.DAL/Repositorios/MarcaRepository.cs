using Dapper;
using Fiap03.DAL.Interfaces;
using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap03.DAL.Repositorios
{
    public class MarcaRepository : IMarcaRepository
    {
        public IList<MarcaMOD> Buscar(int cnpj)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = "SELECT * FROM Marca WHERE Cnpj LIKE '%@Cnpj%'";

                return db.Query<MarcaMOD>(sql, new { Cnpj = cnpj }).ToList();
            }
        }

        public void Cadastrar(MarcaMOD marca)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = "INSERT INTO Marca VALUES (@Nome, @DataCriacao, @Cnpj); SELECT CAST(SCOPE_IDENTITY() as int)";

                int id = db.Query<int>(sql, marca).Single();
                marca.Id = id;
            }
        }

        public bool Editar(MarcaMOD marca)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = "UPDATE Marca SET Nome = @Nome, Cnpj = @Cnpj, DataCriacao = @DataCriacao WHERE Id = @Id";

                return db.Execute(sql, marca) > 0;
            }
        }

        public bool Excluir(int codigo)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = "DELETE FROM Marca WHERE Id = @Id";

                return db.Execute(sql, new { Id = codigo }) > 0;
            }
        }

        public IList<MarcaMOD> Listar()
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = "SELECT * FROM Marca";

                return db.Query<MarcaMOD>(sql).ToList();
            }
        }

        public IList<CarroMOD> ListarCarrosAtrelados(int id)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = @"SELECT 
                                    *
                                FROM Carro
                                INNER JOIN Marca
                                    ON Carro.MarcaId = Marca.Id
                                WHERE MarcaId = @Id";

                var carros = db.Query<CarroMOD, MarcaMOD, CarroMOD>(sql,
                    (carro, marca) =>
                    {
                        carro.MarcaId = marca.Id;
                        return carro;
                    }, new { Id = id }, splitOn: "MarcaId, Id").ToList();

                return carros;
            }
        }

        public MarcaMOD ListarMarca(int codigo)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = "SELECT * FROM Marca WHERE Id = @Id";

                return db.Query<MarcaMOD>(sql, new { Id = codigo }).FirstOrDefault();
            }
        }
    }
}
