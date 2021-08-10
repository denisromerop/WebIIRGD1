using System.Collections.Generic;


namespace WebCampeonato.Models
{
    public partial class Cartao
    {
        public Cartao()
        {
            JogoJogadorCartao = new HashSet<JogoJogadorCartao>();
        }
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<JogoJogadorCartao> JogoJogadorCartao { get; set; }

        public Cartao(int id,string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
