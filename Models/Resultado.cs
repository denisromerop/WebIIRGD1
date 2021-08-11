using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCampeonato.Models
{
    public partial class Resultado
    {
        public int id { get; set; }
        public int? idjogo { get; set; }
        public int? idTime { get; set; }
        public int Vitorias { get; set; }
        public int empates { get; set; }
        public int derrotas { get; set; }
        public int golsPro { get; set; }
        public int golsContra { get; set; }
        public int saldodeGol { get; set; }
        public int qtdjogos { get; set; }
        public int PontosGanhos { get; set; }

        public Jogo IdJogoNavigation { get; set; }
        public Time IdTimeNavigation { get; set; }
    }

}
