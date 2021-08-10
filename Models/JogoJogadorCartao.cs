using System;
using System.Collections.Generic;

namespace WebCampeonato.Models
{
    public partial class JogoJogadorCartao
    {
        public int Id { get; set; }
        public int? IdJogo { get; set; }
        public int? IdJogador { get; set; }
        public int? IdCartao { get; set; }

        public Cartao IdCartaoNavigation { get; set; }
        public Jogador IdJogadorNavigation { get; set; }
        public Jogo IdJogoNavigation { get; set; }
    }
}
