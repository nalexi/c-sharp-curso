using ExercicioCurso.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioCurso.Helpers
{
    public class EstadoHelper
    {
        public static List<Estado> Estados = new List<Estado>()
            {
              new Estado("Acre", 0),
                new Estado("Alagoas (AL)", 1),
                new Estado("Amapá (AP)", 2),
                new Estado("Amazonas (AM)", 3),
                new Estado("Bahia (BA)", 4),
                new Estado("Ceará (CE)", 5),
                new Estado("Distrito Federal (DF)", 6),
                new Estado("Espírito Santo (ES)", 7),
                new Estado("Goiás (GO)", 8),
                new Estado("Maranhão (MA)", 9),
                new Estado("Mato Grosso (MT)", 10),
                new Estado("Mato Grosso do Sul (MS)", 11),
                new Estado("Minas Gerais (MG)", 12),
                new Estado("Pará (PA)", 13),
                new Estado("Paraíba (PB)", 14),
                new Estado("Paraná (PR)", 15),
                new Estado("Pernambuco (PE)", 16),
                new Estado("Piauí (PI)", 17),
                new Estado("Rio de Janeiro (RJ)", 18),
                new Estado("Rio Grande do Norte (RN)", 19),
                new Estado("Rio Grande do Sul (RS)", 20),
                new Estado("Rondônia (RO)", 21),
                new Estado("Roraima (RR)", 22),
                new Estado("Santa Catarina (SC)", 23),
                new Estado("São Paulo (SP)", 24),
                new Estado("Sergipe (SE)", 25),
                new Estado("Tocantins (TO)", 26)
            };
    }
}