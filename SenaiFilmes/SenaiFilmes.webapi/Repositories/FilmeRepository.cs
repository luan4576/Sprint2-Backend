using SenaiFilmes.webapi.Domains;
using SenaiFilmes.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiFilmes.webapi.Repositories
{
    public class FilmeRepository : IFilmeRepository

    {
        private string StringConexao = "Data Source=DEV201\\SQLEXPRESS;initial catalog=Filmes; user Id=sa;pwd=sa@132";

        public void AtualizarUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "UPDATE Filme SET Titulo = @Titulo, IDGenero = @IDGenero WHERE IDFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IDGenero", filme.IdGenero);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void Cadastrar(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "INSERT INTO Filme(Titulo, IDGenero) VALUES (@Titulo, @ID)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                cmd.Parameters.AddWithValue("@ID", filme.IdGenero);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }





        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "DELETE FROM Filme WHERE IDFilme=@ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }





        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IDFilme, Titulo, Filme.IDGenero FROM Filme INNER JOIN Genero ON Filme.IDGenero = Genero.IDGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(rdr[2]),
                        };

                        filmes.Add(filme);
                    }


                }
            }
            return filmes;
        }




        public FilmeDomain ListarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryListarPorId = "SELECT IdFilme , Titulo ,IdGenero FROM Filme WHERE IdFilme =@ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryListarPorId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            Titulo = rdr[1].ToString(),
                            IdGenero = Convert.ToInt32(rdr[2])
                        };
                        return filme;
                    }
                    return null;
                }
            }
        }
    }
}
