using ExercicioCurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioCurso.Interfaces
{
    interface IPessoaRepositorio
    {
        List<Pessoa> ObterTodos(string busca);

        Pessoa ObterPeloId(int id);

        int Inserir(Pessoa pessoa);

        void Alterar(Pessoa pessoa);

        void Apagar(int id);
    }
}