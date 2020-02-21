using SenaiFilmes.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiFilmes.webapi.Interfaces
{
    interface IGeneroRepository
    {
        /// <summary>
        /// Lista todos os generos
        /// </summary>
        /// <returns>retorna uma lista de generos</returns>
        List<GeneroDomain> Listar();


        //retorno nome metodo
        /// <summary>
        /// cadastrar um novo genero
        /// </summary>
        /// <param name="genero"></param> 
        void Cadastrar(GeneroDomain genero);

        /// <summary>
        /// deletar um genero
        /// </summary>
        /// <param name="id"></param>id do genero que sera deletado
        void Deletar(int id);


        /// <summary>
        /// Atualiza um genero existente
        /// </summary>
        /// <param name="genero">objeto genero que sera atualizado</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// atualiza um genero existente
        /// </summary>
        /// <param name="id"></param>id do genero que sera atualizado
        /// <param name="genero"></param>objeto que sera atualizado
        void AtualizarIdUrl(int id, GeneroDomain genero);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GeneroDomain BuscarPorId(int id);
    }
}

