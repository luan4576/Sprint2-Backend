using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class TipoUsuariosDomain
    {
        public int IdTipoUsuario { get; set; }




        [Required(ErrorMessage = "O título do tipo de usuário é obrigatório!")]
        public string TituloTipoUsuario { get; set; }
    }
}
