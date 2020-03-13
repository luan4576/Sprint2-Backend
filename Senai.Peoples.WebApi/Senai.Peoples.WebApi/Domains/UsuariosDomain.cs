﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class UsuariosDomain
    {
        public int IdUsuario { get; set; }


        // Define que o e-mail é obrigatório
        [Required(ErrorMessage = "Informe o e-mail do usuário")]
        // Define o tipo do dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Informe a senha do usuário")]
        // Define o tipo do dado
        [DataType(DataType.Password)]
        // Define os requisitos da senha
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A senha deve conter no mínimo 5 e no máximo 30 caracteres")]
        public string Senha { get; set; }

        public int IdTipoUsuario { get; set; }

        public TipoUsuariosDomain TipoUsuarios { get; set; }
    }
}
