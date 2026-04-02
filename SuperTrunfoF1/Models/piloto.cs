using SuperTrunfoF1.Enums;

namespace SuperTrunfoF1.Models
{
    public class Piloto
    {
        public string Nome { get; }
        public string Equipe { get; }
        public int Experiencia { get; }
        public int Vitorias { get; }
        public int Podios { get; }
        public int PolePositions { get; }
        public int Titulos { get; }
        public bool EhSuperTrunfo { get; }

        public Piloto(string nome, string equipe, int experiencia, int vitorias, int podios, int polePositions, int titulos, bool ehSuperTrunfo = false)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido.");

            if (string.IsNullOrWhiteSpace(equipe))
                throw new ArgumentException("Equipe inválida.");

            if (experiencia < 0 || vitorias < 0 || podios < 0 || polePositions < 0 || titulos < 0)
                throw new ArgumentException("Os atributos não podem ser negativos.");

            Nome = nome;
            Equipe = equipe;
            Experiencia = experiencia;
            Vitorias = vitorias;
            Podios = podios;
            PolePositions = polePositions;
            Titulos = titulos;
            EhSuperTrunfo = ehSuperTrunfo;
        }

        public int ObterValorAtributo(Atributo atributo)
        {
            return atributo switch
            {
                Atributo.Experiencia => Experiencia,
                Atributo.Vitorias => Vitorias,
                Atributo.Podios => Podios,
                Atributo.PolePositions => PolePositions,
                Atributo.Titulos => Titulos,
                _ => throw new ArgumentException("Atributo inválido.")
            };
        }

        public void ExibirCarta()
        {
            Console.WriteLine("==================================");
            Console.WriteLine($"Piloto: {Nome}");
            Console.WriteLine($"Equipe: {Equipe}");

            if (EhSuperTrunfo)
               Console.WriteLine("Carta Super Trunfo!");

            Console.WriteLine($"1 - Experiência: {Experiencia}");
            Console.WriteLine($"2 - Vitórias: {Vitorias}");
            Console.WriteLine($"3 - Pódios: {Podios}");
            Console.WriteLine($"4 - Pole Positions: {PolePositions}");
            Console.WriteLine($"5 - Títulos: {Titulos}");
            Console.WriteLine("==================================");
        }
    }
}