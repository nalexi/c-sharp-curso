using ExercicioCurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioCurso.Interfaces
{
    interface ICursoRepositorio
    {
        List<Curso> ObterTodos(string busca);

        Curso ObterPeloId(int id);

        int Inserir(Curso curso);

        void Alterar(Curso curso);

        void Apagar(int id);
    }
}