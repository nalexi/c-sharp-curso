using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioCurso.Models
{
    public class Inscricao
    {
        public int Id;
        public string Nome;
        public bool RegistroAtivo;

        public override string ToString()
        {
            return Id + " " + Nome + " " + RegistroAtivo;
        }
    }
}