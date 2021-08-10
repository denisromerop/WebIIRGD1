using System;
using System.Collections.Generic;

namespace WebCampeonato.Models
{
    public partial class JogoArbitro
    {
        public int Id { get; set; }
        public int? IdJogo { get; set; }
        public int? IdArbitro { get; set; }

        public Arbitro IdArbitroNavigation { get; set; }
        public Jogo IdJogoNavigation { get; set; }
    }
}
