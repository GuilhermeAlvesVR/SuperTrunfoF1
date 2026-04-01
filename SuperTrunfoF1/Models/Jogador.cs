namespace SuperTrunfoF1.Models
{
    public class Jogador
    {
        public string Nome { get; private set; }
        public IReadOnlyList<Piloto> Cartas => _cartas;
        public int Pontuacao { get; private set; }

        private List<Piloto> _cartas;

        public Jogador(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do jogador não pode ser vazio.");

            Nome = nome;
            _cartas = new List<Piloto>();
            Pontuacao = 0;
        }

        public void AdicionarCarta(Piloto carta)
        {
            if (carta == null)
                throw new ArgumentNullException(nameof(carta), "A carta não pode ser nula.");
            _cartas.Add(carta);
        }

        public void AdicionarPonto()
        {
            Pontuacao++;
        }

        public void Resetar()
        {
            _cartas.Clear();
            Pontuacao = 0;
        }
    }
}