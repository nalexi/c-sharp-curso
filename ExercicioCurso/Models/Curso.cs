using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioCurso.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Tema { get; set; }
        public int Inscritos { get; set; }
        public DateTime DataCurso { get; set; }
        public bool Confirmado { get; set; }
        public int Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public decimal Valor { get; set; }
        public bool RegistroAtivo { get; set; }

    }
}