using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class TipoUsuariosRepository : ITipoUsuariosRepository
    {
        private string StringConexao = "Data Source=DEV201\\SQLEXPRESS;initial catalog=M_Peoples; user Id=sa;pwd=sa@132";

        public void AtualizarIdUrl(int id, TipoUsuariosDomain tipoUsuarios)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE TipoUsuarios SET TituloTipoUsuario = @TituloTipoUsuario  WHERE IdTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@TituloTipoUsuario", tipoUsuarios.TituloTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();


                }
            }
        }

        public TipoUsuariosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdTipoUsuario,TituloTipoUsuario FROM TipoUsuarios WHERE IdTipoUsuario = @ID";

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
                        TipoUsuariosDomain tipoUsuarios = new TipoUsuariosDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipousuario"]),

                            TituloTipoUsuario = rdr["TituloTipoUsuario"].ToString(),

                        };
                        return tipoUsuarios;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDeletar = "DELETE FROM TipoUsuarios WHERE IdTipoUsuarios =@ID ";

                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TipoUsuariosDomain> Listar()
        {
                List<TipoUsuariosDomain> tipoUsuarios = new List<TipoUsuariosDomain>();

                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string query = "SELECT IdTipoUsuario,TituloTipoUsuario FROM TipoUsuarios";

                    con.Open();

                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(query, con))

                        rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                    TipoUsuariosDomain tipoUsuario = new TipoUsuariosDomain
                    {
                        IdTipoUsuario = Convert.ToInt32(rdr[0]),
                        TituloTipoUsuario = rdr["TituloTipoUsuario"].ToString()
                           
                        };

                        tipoUsuarios.Add(tipoUsuario);
                    }
                }
                return tipoUsuarios;
            
        }
    }
}
