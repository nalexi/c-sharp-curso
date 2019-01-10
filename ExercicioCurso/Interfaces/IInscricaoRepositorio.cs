using ExercicioCurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioCurso.Interfaces
{
    interface IInscricaoRepositorio
    {
        List<Inscricao> ObterTodos(string busca);

        Inscricao ObterPeloId(int id);

        int Inserir(Inscricao inscricao);

        void Alterar(Inscricao inscricao);

        void Apagar(int id);
    }
}