using Fiap04.Api.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap04.Api.Client.DAL.Interface
{
    public interface ICarroRespository
    {
        void Cadastrar(CarroModel carro);
        IList<CarroModel> Listar();
        void Excluir(int codigo);
        CarroModel ListarCarro(int codigo);
        IList<CarroModel> Buscar(int ano);
        bool Editar(CarroModel carro);
        bool ValidarPlaca(string placa);

    }
}
