using Fiap03.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap03.DAL.Interfaces
{
    public interface IMarcaRepository
    {
        void Cadastrar(MarcaMOD marca);

        IList<MarcaMOD> Listar();

        bool Excluir(int codigo);

        MarcaMOD ListarMarca(int codigo);

        IList<MarcaMOD> Buscar(int cnpj);

        bool Editar(MarcaMOD marca);

        IList<CarroMOD> ListarCarrosAtrelados(int id);

    }
}
