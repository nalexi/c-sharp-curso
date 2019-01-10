using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioCurso.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}