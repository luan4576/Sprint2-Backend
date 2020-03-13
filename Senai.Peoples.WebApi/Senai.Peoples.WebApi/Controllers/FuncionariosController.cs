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
{   [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionariosRepository _funcionariosRepository { get; set; }
        public FuncionariosController()
        {
            _funcionariosRepository = new FuncionariosRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionariosDomain> get ()
        {
            return _funcionariosRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(FuncionariosDomain NovoFuncionario)
        {
            _funcionariosRepository.Cadastrar(NovoFuncionario);
            return StatusCode(201);
        }

        [HttpPut ("{id}")]
        public IActionResult PutUrl(int id , FuncionariosDomain funcionarioAtualizado)
        {
            FuncionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);

            if (funcionarioBuscado == null)
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
                _funcionariosRepository.AtualizarIdUrl(id, funcionarioAtualizado);
                return NoContent();
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            FuncionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);

            if(funcionarioBuscado == null)
            {
                return NotFound("nenhum funcionario encontrado");
            }
            return Ok(funcionarioBuscado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _funcionariosRepository.Deletar(id);

            return Ok("Funcionario Deletado");
        }

       

    }
}
