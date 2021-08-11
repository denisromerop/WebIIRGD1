using System;
using System.Collections.Generic;

namespace WebCampeonato.Models

{
    public partial class Time
    {
        public Time()
        {
            Jogador = new HashSet<Jogador>();
            TimeJogo = new HashSet<TimeJogo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Vitorias { get; set; }
        public int? Empates { get; set; }
        public int? Derrotas { get; set; }
        public int? Gp { get; set; }
        public int? Gc { get; set; }
        public string EscudoCaminho { get; set; }
        public string FotoOficialCaminho { get; set; }

        public ICollection<Jogador> Jogador { get; set; }
        public ICollection<TimeJogo> TimeJogo { get; set; }
        public ICollection<Resultado> Resultado { get; set; }

        public Time(int id, string nome, int? vitorias, int? empates, int? derrotas, int? gp, int? gc, string escudoCaminho, string fotoOficialCaminho)
        {
            Id = id;
            Nome = nome;
            Vitorias = vitorias;
            Empates = empates;
            Derrotas = derrotas;
            Gp = gp;
            Gc = gc;
            EscudoCaminho = escudoCaminho;
            FotoOficialCaminho = fotoOficialCaminho;
        }
    }
}
