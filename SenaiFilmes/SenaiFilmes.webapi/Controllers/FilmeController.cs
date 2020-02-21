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
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FilmeDomain filmeBuscado = _filmeRepository.ListarPorId(id);

            if (filmeBuscado == null)
            {
                return NotFound("Nenhum Filme encontrado");
            }

            return StatusCode(200, filmeBuscado);
        }




        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain filme)
        {
            _filmeRepository.Cadastrar(filme);
            return StatusCode(201);
        }




        [HttpPut("{id}")]
        public IActionResult Update(int id, FilmeDomain filme)
        {
            FilmeDomain filmeBuscado = _filmeRepository.ListarPorId(id);

            if (filmeBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Filme não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _filmeRepository.AtualizarUrl(id, filme);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _filmeRepository.Deletar(id);
            return Ok("Filme Deletado");
        }

    }
}
    
