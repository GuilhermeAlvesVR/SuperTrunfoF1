namespace SuperTrunfoF1.Models
{
    public class Jogador
    {
        public string Nome { get; set; }
        public List<Piloto> Cartas { get; set; }
        public int Pontuacao { get; set; }

        public Jogador(string nome)
        {
            Nome = nome;
            Cartas = new List<Piloto>();
            Pontuacao = 0;
        }
    }
}