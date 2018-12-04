using Fiap04.Api.Client.DAL.Interface;
using Fiap04.Api.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fiap04.Api.Client.DAL
{
    public class CarroRepository : ICarroRespository
    {
        public IList<CarroModel> Buscar(int ano)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(CarroModel carro)
        {
            throw new NotImplementedException();
        }

        public bool Editar(CarroModel carro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int codigo)
        {
            throw new NotImplementedException();
        }

        public IList<CarroModel> Listar()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:22345/");
                HttpResponseMessage response =
                    client.PostAsJsonAsync("api/carro", CarroModel).Result;
                if (response.IsSuccessStatusCode)
                {
                    Uri uri = response.Headers.Location;
                }
            }
        }

        public CarroModel ListarCarro(int codigo)
        {
            throw new NotImplementedException();
        }

        public bool ValidarPlaca(string placa)
        {
            throw new NotImplementedException();
        }
    }
}
