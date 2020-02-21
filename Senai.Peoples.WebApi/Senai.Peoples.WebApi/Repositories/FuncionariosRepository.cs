using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private string StringConexao = "Data Source=DEV201\\SQLEXPRESS;initial catalog=M_Peoples; user Id=sa;pwd=sa@132";

        public void AtualizarIdUrl(int id, FuncionariosDomain funcionarios)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome , SobreNome = @SobreNome WHERE IdFuncionarios = @ID";
                
                    using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                        cmd.Parameters.AddWithValue("@SobreNome",funcionarios.SobreNome);

                        con.Open();

                        cmd.ExecuteNonQuery();


                    }
            }
        }

        public FuncionariosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdFuncionarios, Nome ,SobreNome FROM Funcionarios WHERE IdFuncionarios = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader fazer a leitura no banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        FuncionariosDomain funcionarios = new FuncionariosDomain
                        {
                            IdFuncionarios = Convert.ToInt32(rdr["IdFuncionarios"]),

                            Nome = rdr["Nome"].ToString(),

                            SobreNome = rdr["SobreNome"].ToString()
                        };
                        return funcionarios;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(FuncionariosDomain funcionarios)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Funcionarios(Nome,SobreNome) VALUES (@Nome,@SobreNome)";

                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                cmd.Parameters.AddWithValue("@SobreNome", funcionarios.SobreNome);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDeletar = "DELETE FROM Funcionarios WHERE IdFuncionarios =@ID ";

                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdFuncionarios,Nome,SobreNome FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))

                    rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    FuncionariosDomain funcionario = new FuncionariosDomain
                    {
                        IdFuncionarios = Convert.ToInt32(rdr[0]),
                        Nome = rdr["Nome"].ToString(),
                        SobreNome = rdr["SobreNome"].ToString()
                    };

                    funcionarios.Add(funcionario);
                }
            }
            return funcionarios;
        }
       
    }
}
