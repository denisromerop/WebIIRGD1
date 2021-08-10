using System;
using System.Collections.Generic;

namespace WebCampeonato.Models
{
    public partial class Jogo
    {
        public Jogo()
        {
            JogoArbitro = new HashSet<JogoArbitro>();
            JogoJogadorCartao = new HashSet<JogoJogadorCartao>();
            TimeJogo = new HashSet<TimeJogo>();
        }

        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataHora { get; set; }

        public ICollection<JogoArbitro> JogoArbitro { get; set; }
        public ICollection<JogoJogadorCartao> JogoJogadorCartao { get; set; }
        public ICollection<TimeJogo> TimeJogo { get; set; }
    }
}
