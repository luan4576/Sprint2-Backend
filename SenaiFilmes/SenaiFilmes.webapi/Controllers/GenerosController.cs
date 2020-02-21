using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiFilmes.webapi.Domains;
using SenaiFilmes.webapi.Interfaces;
using SenaiFilmes.webapi.Repositories;

namespace SenaiFilmes.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    ///api/Generos
    [ApiController]


    public class GenerosController : ControllerBase
    {
        private IGeneroRepository _generoRepository { get; set; }
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        [HttpGet]
        public IEnumerable<GeneroDomain> Get()
        {
            return _generoRepository.Listar();
        }
       
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            _generoRepository.Cadastrar(novoGenero);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _generoRepository.Deletar(id);

            return Ok("Gênero deletado");
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if(generoBuscado == null)
            {
                return NotFound("nenhum genero encontrado");
            }
            return Ok( generoBuscado);
        }

        public IActionResult PutIdCorpo(GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.IdGenero);

            // Verifica se algum gênero foi encontrado
            if (generoBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo();
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna BadRequest e o erro
                    return BadRequest(erro);
                }

            }

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para representar que houve erro
            return NotFound
                (
                    new
                    {
                        mensagem = "Gênero não encontrado",
                        erro = true
                    }
                );
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id , GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound
                    (
                    new
                    {
                        mensagem = "nenhum genero encontrado",
                        erro = true
                    }
                    );
            }

            try
            {
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                return NoContent();
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }

          
        }
    }
}