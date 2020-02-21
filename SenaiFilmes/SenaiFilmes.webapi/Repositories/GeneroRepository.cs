using SenaiFilmes.webapi.Domains;
using SenaiFilmes.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiFilmes.webapi.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string StringConexao = "Data Source=DEV201\\SQLEXPRESS;initial catalog=Filmes; user Id=sa;pwd=sa@132";

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", genero.IdGenero);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
    

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID",id);
                    cmd.Parameters.AddWithValue("Nome", genero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();


                }
            }
        }

        public void Cadastrar(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Generos(Nome) VALUES (@Nome)";

                SqlCommand cmd = new SqlCommand(queryInsert, con);
                
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    con.Open();
                    cmd.ExecuteNonQuery();
                
            } 
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDeletar = "DELETE FROM Generos WHERE IdGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                
            }
        }

        public GeneroDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdGenero, Nome FROM Generos WHERE IdGenero = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader fazer a leitura no banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Caso a o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Cria um objeto genero
                        GeneroDomain genero = new GeneroDomain
                        {
                            // Atribui à propriedade IdGenero o valor da coluna "IdGenero" da tabela do banco
                            IdGenero = Convert.ToInt32(rdr["IdGenero"])

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            ,
                            Nome = rdr["Nome"].ToString()
                        };

                        // Retorna o genero com os dados obtidos
                        return genero;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }


        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdGenero,Nome FROM Genero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString()
                        };

                        generos.Add(genero);
                    }

                    
                }
            }
            return generos;
        }


    }
}
