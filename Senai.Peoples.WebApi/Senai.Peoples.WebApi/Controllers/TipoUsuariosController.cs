using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuariosRepository _tipoUsuariosRepository { get; set; }
        public TipoUsuariosController()
        {
            _tipoUsuariosRepository = new TipoUsuariosRepository();
        }

        [HttpGet]
        public IEnumerable<TipoUsuariosDomain> get()
        {
            return _tipoUsuariosRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoUsuariosDomain tipoUsuariosBuscado = _tipoUsuariosRepository.BuscarPorId(id);

            if (tipoUsuariosBuscado == null)
            {
                return NotFound("nenhum tipo usuario encontrado");

            }
            return Ok("Funcionario Deletado");
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, TipoUsuariosDomain tipoUsuariosAtualizado)
        {
            TipoUsuariosDomain tipoUsuariosBuscado = _tipoUsuariosRepository.BuscarPorId(id);

            if (tipoUsuariosBuscado == null)
            {
                return NotFound
                    (
                    new
                    {
                        mensagem = "nenhum funcionario encontrado",
                        erro = true
                    }
                    );
            }

            try
            {
                _tipoUsuariosRepository.AtualizarIdUrl(id, tipoUsuariosAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _tipoUsuariosRepository.Deletar(id);

            return Ok("Funcionario Deletado");
        }

    }
}