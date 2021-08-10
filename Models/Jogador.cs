using System;
using System.Collections.Generic;

namespace WebCampeonato.Models
{
    public partial class Jogador
    {
        public Jogador()
        {
            JogoJogadorCartao = new HashSet<JogoJogadorCartao>();
        }

        public enum posicaoJogadorenum { Goleiro, Zagueiro, Laterial, meiocampo, Atacante}

        public int Id { get; set; }
        public int? IdTime { get; set; }
        public string Nome { get; set; }
        public int? Numero { get; set; }
        public string Posicao { get; set; }
        public int? Gols { get; set; }
        public byte[] Foto { get; set; }

        public Time IdTimeNavigation { get; set; }
        public ICollection<JogoJogadorCartao> JogoJogadorCartao { get; set; }
    }
}
