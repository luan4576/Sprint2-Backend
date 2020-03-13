using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private string StringConexao = "Data Source=DEV201\\SQLEXPRESS;initial catalog=M_Peoples; user Id=sa;pwd=sa@132";

        public void Atualizar(int id, UsuariosDomain UsuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public UsuariosDomain BuscarPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public UsuariosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdUsuario,Email,Senha FROM Usuarios WHERE IdUsuario = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader fazer a leitura no banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuariosDomain usuarios = new UsuariosDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),

                           Email = rdr["Email"].ToString(),

                            Senha = rdr["Senha"].ToString(),


                        };
                        return usuarios;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(UsuariosDomain novoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsuariosDomain> Listar()
        {
            List<UsuariosDomain> usuarios = new List<UsuariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdUsuario,Email,Senha,TipoUsuario,Titulo FROM Usuarios INNER JOIN TipoUsuarios = IdTipoUsuarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))

                    rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    UsuariosDomain usuario = new UsuariosDomain
                    {
                        IdUsuario = Convert.ToInt32(rdr[0]),
                        Email = rdr["Email"].ToString(),
                        Senha = rdr["Senha"].ToString()
                    };

                    usuarios.Add(usuario);
                }
            }
            return usuarios;
        }
    }
}
