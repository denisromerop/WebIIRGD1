using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCampeonato.Models
{
    public class Resultado
    {
        public string nome { get; set; }
        public int Vitorias { get; set; }
        public int empates { get; set; }
        public int derrotas { get; set; }
        public int golsPro { get; set; }
        public int golsContra { get; set; }
        public int saldodeGol { get; set; }
        public int qtdjogos { get; set; }
        public int PontosGanhos { get; set; }
    }
}
