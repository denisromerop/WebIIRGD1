using System;
using System.Collections.Generic;

namespace WebCampeonato.Models
{
    public partial class Arbitro
    {
        public Arbitro()
        {
            JogoArbitro = new HashSet<JogoArbitro>();  
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set; }
        public bool? Fifa { get; set; }
        public string Federacao { get; set; }
        public byte[] Foto { get; set; }

        public ICollection<JogoArbitro> JogoArbitro { get; set; }


        public Arbitro(int id, string nome, string posicao, bool? fifa, string federacao, byte[] foto)
        {
            Id = id;
            Nome = nome;
            Posicao = posicao;
            Fifa = fifa;
            Federacao = federacao;
            Foto = foto;
        }
    }
}
