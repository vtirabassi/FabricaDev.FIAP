using Dapper;
using Fiap03.DAL.Repositorios.Interfaces;
using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Fiap03.DAL.Repositorios
{
    public class CarroRepository : ICarroRepository
    {
        public IList<CarroMOD> Buscar(int ano)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = "SELECT * FROM Carro INNER JOIN Documento ON Carro.Renavam = Documento.Renavam WHERE Carro.Ano = @Ano OR 0 = @Ano";

                var carros = db.Query<CarroMOD, DocumentoMOD, CarroMOD>(sql,
                    (carro, documento) =>
                    {
                        carro.Documento = documento;
                        return carro;
                    }, new { Ano = ano }, splitOn: "Renavam, Renavam").ToList();

                return carros;
            }
        }

        public void Cadastrar(CarroMOD carro)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                using (var txScope = new TransactionScope())
                {
                    string sql = "INSERT INTO Documento VALUES(@Renavam, @DataFabricacao, @Categoria)";

                    db.Execute(sql, carro.Documento);

                    string sql2 = "INSERT INTO Carro VALUES (@MarcaId, @Ano, @Esportivo, @Placa, @Descricao, @Combustivel, @Renavam, @ModeloId); SELECT CAST(SCOPE_IDENTITY() as int)";

                    carro.Renavam = carro.Documento.Renavam;
                    int id = db.Query<int>(sql2, carro).Single();
                    carro.Id = id;

                    txScope.Complete();
                }
            }
        }

        public bool Editar(CarroMOD carro)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                using (var txScope = new TransactionScope())
                {
                    string sql = "UPDATE Documento SET Categoria = @Categoria, DataFabricacao = @DataFabricacao WHERE Renavam = @Renavam";

                    db.Execute(sql, carro.Documento);

                    string sql2 = "UPDATE Carro SET MarcaId = @MarcaId, Combustivel = @Combustivel, Esportivo = @Esportivo, Placa = @Placa, Ano = @Ano, Descricao = @Descricao WHERE Id = @Id";

                    carro.Renavam = carro.Documento.Renavam;

                    return db.Execute(sql2, carro) > 0;
                    txScope.Complete();
                }
            }
        }

        public void Excluir(int codigo)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = "DELETE FROM Carro WHERE Id = @Id";

                var deletado = db.Execute(sql, new { Id = codigo });
            }
        }

        public IList<CarroMOD> Listar()
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = "SELECT * FROM Carro INNER JOIN Documento ON Carro.Renavam = Documento.Renavam";

                var carros = db.Query<CarroMOD, DocumentoMOD, CarroMOD>(sql,
                    (carro, documento) =>
                    {
                        carro.Documento = documento;
                        return carro;
                    }, splitOn: "Renavam, Renavam").ToList();
                return carros;
            }
        }

        public CarroMOD ListarCarro(int codigo)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = "SELECT * FROM Carro INNER JOIN Documento ON Carro.Renavam = Documento.Renavam WHERE Id = @Id";

                var carroDet = db.Query<CarroMOD, DocumentoMOD, CarroMOD>(sql,
                    (carro, documento) =>
                    {
                        carro.Documento = documento;
                        return carro;
                    }, new { Id = codigo }, splitOn: "Renavam, Renavam").FirstOrDefault();
                return carroDet;
            }
        }

        public bool ValidarPlaca(string placa)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = @"SELECT * FROM Carro WHERE Placa = @Placa";

                var existe = db.QueryFirstOrDefault(sql, new { Placa = placa });
                if (existe != null)
                    return true;
                return false;
            }
        }

        public bool VerificaCarroModelo(int id)
        {
            using (var db = ConnectionFactories.ConnectionFactory.GetConnection())
            {
                string sql = @"SELECT * FROM Carro WHERE ModeloId = @Id";

                var existe = db.QueryFirstOrDefault(sql, new { Id = id });
                if (existe != null)
                    return true;
                return false;
            }
        }
    }
}
