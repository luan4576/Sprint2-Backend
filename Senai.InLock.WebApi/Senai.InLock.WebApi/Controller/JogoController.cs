﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repository;

namespace Senai.InLock.WebApi.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class JogoController : ControllerBase
    {
        private IJogosRepository _jogosRepository { get; set; }

        public JogoController()
        {
            _jogosRepository = new JogosRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Retorna todos os jogos</returns>
        [HttpGet]
        public IEnumerable<JogoDomain> Get()
        {
            return _jogosRepository.Listar();
        }


        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="cadastrarJogo">Novo jogo que será cadastrado</param>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(JogoDomain novoJogo)
        {
            _jogosRepository.Cadastrar(novoJogo);
            return StatusCode(201);
        }
    }
}