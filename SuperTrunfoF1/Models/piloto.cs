using SuperTrunfoF1.Enums;

namespace SuperTrunfoF1.Models
{
    public class Piloto
    {
        public string Nome { get; set; }
        public string Equipe { get; set; }
        public int Experiencia { get; set; }
        public int Vitorias { get; set; }
        public int Podios { get; set; }
        public int PolePositions { get; set; }
        public int Titulos { get; set; }
        public bool EhSuperTrunfo { get; set; }

        public Piloto(string nome, string equipe, int experiencia, int vitorias, int podios, int polePositions, int titulos, bool ehSuperTrunfo = false)
        {
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
                _ => 0
            };
        }

        public void ExibirCarta()
        {
            Console.WriteLine("==================================");
            Console.WriteLine($"Piloto: {Nome}");
            Console.WriteLine($"Equipe: {Equipe}");

            if (EhSuperTrunfo)
            {
                Console.WriteLine("Carta Super Trunfo!");
            }

            Console.WriteLine($"1 - Experiência: {Experiencia}");
            Console.WriteLine($"2 - Vitórias: {Vitorias}");
            Console.WriteLine($"3 - Pódios: {Podios}");
            Console.WriteLine($"4 - Pole Positions: {PolePositions}");
            Console.WriteLine($"5 - Títulos: {Titulos}");
            Console.WriteLine("==================================");
        }
    }
}