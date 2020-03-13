using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IUsuariosRepository
    {
        List<UsuariosDomain> Listar();

        UsuariosDomain BuscarPorId(int id);

        void Cadastrar(UsuariosDomain novoUsuario);

        void Atualizar(int id, UsuariosDomain UsuarioAtualizado);

        void Deletar(int id);

        UsuariosDomain BuscarPorEmailSenha(string email, string senha);

    }
}
