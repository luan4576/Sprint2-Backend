using SenaiFilmes.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiFilmes.webapi.Interfaces
{
    interface IFilmeRepository
    {
        List<FilmeDomain> Listar();

        FilmeDomain ListarPorId(int id);

        void Cadastrar(FilmeDomain filme);

        void AtualizarUrl(int id, FilmeDomain filme);

        void Deletar(int id);
    }
}
