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

    [Authorize(Roles = "1")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Retorna todos os estudios</returns>
        [HttpGet]
        public IEnumerable<EstudioDomain> Get()
        {
            return _estudioRepository.Listar();
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="cadastrarEstudio">Novo estúdio que será cadastrados</param>
        [HttpPost]
        public IActionResult Cadastrar(EstudioDomain novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);
            return StatusCode(201);
        }
    }
}