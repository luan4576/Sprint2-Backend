using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface ITipoUsuariosRepository
    {
        List<TipoUsuariosDomain> Listar();

        TipoUsuariosDomain BuscarPorId(int id);

        void AtualizarIdUrl(int id, TipoUsuariosDomain tipoUsuarios);

        void Deletar(int id);
    }
}
