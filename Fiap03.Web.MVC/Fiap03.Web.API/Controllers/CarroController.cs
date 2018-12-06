using Fiap03.DAL.Repositorios;
using Fiap03.DAL.Repositorios.Interfaces;
using Fiap03.MOD;
using Fiap03.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Fiap03.Web.API.Controllers
{
    public class CarroController : ApiController
    {
        private ICarroRepository _rep = new CarroRepository();

        public IList<CarroDTO> Get()
        {
            return _rep.Listar().Select(c => new CarroDTO(c)).ToList();
        }

        public CarroDTO Get(int id)
        {
            return new CarroDTO(_rep.ListarCarro(id));
        }

        public IHttpActionResult Post(CarroDTO carro)
        {
            //if (ModelState.IsValid)
            //{
            //    var link = Url.Link("DefaultApi", new { id = carro.Id });
            //    return Created(link, carro);
            //}
            //return BadRequest();

            //AAAARUMAR ISSO AQUI
            var carroMod = new CarroMOD()
            {
                Id = carro.Id,
                MarcaId = carro.MarcaId,
                Ano = carro.Ano,
                Esportivo = carro.Esportivo,
                Placa = carro.Placa,
                Descricao = carro.Descricao,
                Combustivel = carro.Combustivel,
                ModeloId = carro.ModeloId,
                Documento = new DocumentoMOD()
                {
                    Renavam = carro.Documento.Renavam,
                    Categoria = carro.Documento.Categoria,
                    DataFabricacao = carro.Documento.DataFabricacao
                }
            };

            try
            {
                _rep.Cadastrar(carroMod);
                return Ok(carro);
            }
            catch
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int id, CarroDTO carro)
        {
            if (ModelState.IsValid)
            {
                carro.Id = id;
                var a = _rep.Editar(new CarroMOD()
                {
                    Id = carro.Id,
                    MarcaId = carro.MarcaId,
                    Ano = carro.Ano,
                    Esportivo = carro.Esportivo,
                    Placa = carro.Placa,
                    Descricao = carro.Descricao,
                    Combustivel = carro.Combustivel,
                    ModeloId = carro.ModeloId,
                    Documento = new DocumentoMOD()
                    {
                        Renavam = carro.Documento.Renavam,
                        Categoria = carro.Documento.Categoria,
                        DataFabricacao = carro.Documento.DataFabricacao
                    }
                });

                if (a != true)
                {
                    return BadRequest();
                }
                return Ok(carro);

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public void Delete(int id)
        {
            _rep.Excluir(id);
        }
    }
}
