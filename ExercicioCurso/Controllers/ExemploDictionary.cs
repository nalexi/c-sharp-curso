using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioCurso.Controllers
{
    public class ExemploDictionary
    {
        public void SeiLa()
        {
            Dictionary<string, int> idades = new Dictionary<string, int>();
            idades.Add("lucas", 4);
            idades.Add("Francisco", 24);
            idades.Add("Nicholas", 29);
            idades.Add("Nicholas", 30);

            int idadeLucas = idades["lucas"];
        }
    }
}