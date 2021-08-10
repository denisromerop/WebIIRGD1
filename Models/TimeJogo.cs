using System;
using System.Collections.Generic;

namespace WebCampeonato.Models
{
    public partial class TimeJogo
    {
        public int Id { get; set; }
        public int? IdTime { get; set; }
        public int? IdJogo { get; set; }
        public int? Gols { get; set; }

        public Jogo IdJogoNavigation { get; set; }
        public Time IdTimeNavigation { get; set; }

        
    }
}
