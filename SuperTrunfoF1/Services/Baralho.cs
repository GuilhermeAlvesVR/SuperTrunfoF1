using SuperTrunfoF1.Models;

namespace SuperTrunfoF1.Services
{
    public class Baralho
    {
        private static readonly Random rng = new Random();

        public List<Piloto> Cartas { get; private set; }

        public Baralho()
        {
            Cartas = CriarCartas();
        }

        private List<Piloto> CriarCartas()
        {
            return new List<Piloto>
            {
                new Piloto("Lewis Hamilton", "Ferrari", 18, 103, 197, 104, 7),
                new Piloto("Max Verstappen", "Red Bull", 10, 71, 100, 40, 4),
                new Piloto("Fernando Alonso", "Aston Martin", 20, 32, 106, 22, 2),
                new Piloto("Charles Leclerc", "Ferrari", 7, 8, 30, 25, 0),
                new Piloto("Lando Norris", "McLaren", 6, 5, 20, 10, 1),
                new Piloto("Carlos Sainz", "Williams", 9, 3, 20, 5, 0),
                new Piloto("George Russell", "Mercedes", 6, 3, 15, 5, 0),
                new Piloto("Sergio Perez", "Cadillac", 12, 6, 39, 3, 0),
                new Piloto("Valtteri Bottas", "Cadillac", 10, 10, 67, 20, 0),
                new Piloto("Oscar Piastri", "McLaren", 3, 2, 10, 3, 0),
                new Piloto("Esteban Ocon", "Haas", 7, 1, 4, 0, 0),
                new Piloto("Pierre Gasly", "Alpine", 7, 1, 5, 0, 0),
                new Piloto("Alexander Albon", "Williams", 6, 0, 2, 0, 0),
                new Piloto("Lance Stroll", "Aston Martin", 7, 0, 3, 1, 0),
                new Piloto("Nico Hulkenberg", "Audi", 10, 0, 0, 1, 0),
                new Piloto("Yuki Tsunoda", "RB", 4, 0, 1, 0, 0),
                new Piloto("Guanyu Zhou", "Audi", 3, 0, 0, 0, 0),
                new Piloto("Kevin Magnussen", "Haas", 9, 0, 1, 1, 0),
                new Piloto("Daniel Ricciardo", "RB", 13, 8, 32, 3, 0),
                new Piloto("Liam Lawson", "RB", 2, 0, 0, 0, 0),
                new Piloto("Oliver Bearman", "Haas", 1, 0, 1, 0, 0),

                new Piloto("Ayrton Senna", "Lenda", 10, 41, 80, 65, 3, true)
            };
        }

        public void Embaralhar()
        {
            for (int i = Cartas.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (Cartas[i], Cartas[j]) = (Cartas[j], Cartas[i]);
            }
        }
    }
}