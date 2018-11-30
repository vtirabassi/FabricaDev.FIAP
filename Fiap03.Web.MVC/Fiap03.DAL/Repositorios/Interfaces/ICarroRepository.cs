using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap03.DAL.Repositorios.Interfaces
{
    public interface ICarroRepository
    {
        void Cadastrar(CarroMOD carro);
        IList<CarroMOD> Listar();
        void Excluir(int codigo);
        CarroMOD ListarCarro(int codigo);
        IList<CarroMOD> Buscar(int ano);
        bool Editar(CarroMOD carro);
        bool ValidarPlaca(string placa);
        

    
    }
}
