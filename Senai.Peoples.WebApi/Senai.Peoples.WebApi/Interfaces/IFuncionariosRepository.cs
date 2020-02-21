﻿using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionariosRepository
    {

        List<FuncionariosDomain> Listar();

        void Cadastrar(FuncionariosDomain funcionarios);

        void AtualizarIdUrl(int id, FuncionariosDomain funcionarios);

        FuncionariosDomain BuscarPorId(int id);

        void Deletar(int id);
    }
}
