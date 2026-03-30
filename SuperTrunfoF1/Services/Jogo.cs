using SuperTrunfoF1.Enums;
using SuperTrunfoF1.Models;

namespace SuperTrunfoF1.Services
{
    public class Jogo
    {
        public Jogador Usuario { get; set; }
        public Jogador Computador { get; set; }
        public Baralho Baralho { get; set; }

        public Jogo()
        {
            Usuario = new Jogador("Usuário");
            Computador = new Jogador("Computador");
            Baralho = new Baralho();
        }

        public void Iniciar()
        {
            Baralho.Embaralhar();
            DistribuirCartas();
            JogarRodadas();
            ExibirResultadoFinal();
        }

        private void DistribuirCartas()
        {
            for (int i = 0; i < Baralho.Cartas.Count; i++)
            {
                if (i % 2 == 0)
                    Usuario.Cartas.Add(Baralho.Cartas[i]);
                else
                    Computador.Cartas.Add(Baralho.Cartas[i]);
            }
        }

        private void JogarRodadas()
        {
            int totalRodadas = Usuario.Cartas.Count;

            for (int i = 0; i < totalRodadas; i++)
            {
                Console.Clear();
                Console.WriteLine($"========== RODADA {i + 1} ==========\n");

                Piloto cartaUsuario = Usuario.Cartas[i];
                Piloto cartaComputador = Computador.Cartas[i];

                Console.WriteLine("Sua carta:");
                cartaUsuario.ExibirCarta();

                Atributo atributoEscolhido = EscolherAtributo();

                Console.WriteLine($"\nVocê escolheu: {atributoEscolhido}");
                Console.WriteLine("\nCarta do computador:");
                cartaComputador.ExibirCarta();

                int resultado = CompararCartas(cartaUsuario, cartaComputador, atributoEscolhido);

                if (resultado > 0)
                {
                    Console.WriteLine("\nVocê venceu a rodada!");
                    Usuario.Pontuacao++;
                }
                else if (resultado < 0)
                {
                    Console.WriteLine("\nO computador venceu a rodada!");
                    Computador.Pontuacao++;
                }
                else
                {
                    Console.WriteLine("\nA rodada empatou!");
                }

                Console.WriteLine($"\nPlacar: Usuário {Usuario.Pontuacao} x {Computador.Pontuacao} Computador");
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private Atributo EscolherAtributo()
        {
            while (true)
            {
                Console.WriteLine("\nEscolha um atributo:");
                Console.WriteLine("1 - Experiência");
                Console.WriteLine("2 - Vitórias");
                Console.WriteLine("3 - Pódios");
                Console.WriteLine("4 - Pole Positions");
                Console.WriteLine("5 - Títulos");
                Console.Write("Digite o número da opção: ");

                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int opcao) && opcao >= 1 && opcao <= 5)
                {
                    return (Atributo)opcao;
                }

                Console.WriteLine("\nOpção inválida. Tente novamente.");
            }
        }

        public int CompararCartas(Piloto usuario, Piloto computador, Atributo atributo)
        {
            if (usuario.EhSuperTrunfo && computador.EhSuperTrunfo)
                return 0;

            if (usuario.EhSuperTrunfo)
                return 1;

            if (computador.EhSuperTrunfo)
                return -1;

            int valorUsuario = usuario.ObterValorAtributo(atributo);
            int valorComputador = computador.ObterValorAtributo(atributo);

            if (valorUsuario > valorComputador)
                return 1;

            if (valorUsuario < valorComputador)
                return -1;

            return 0;
        }

        private void ExibirResultadoFinal()
        {
            Console.Clear();
            Console.WriteLine("========== FIM DE JOGO ==========\n");
            Console.WriteLine($"Placar final: Usuário {Usuario.Pontuacao} x {Computador.Pontuacao} Computador\n");

            if (Usuario.Pontuacao > Computador.Pontuacao)
                Console.WriteLine("Você venceu o jogo!");
            else if (Usuario.Pontuacao < Computador.Pontuacao)
                Console.WriteLine("O computador venceu o jogo!");
            else
                Console.WriteLine("O jogo terminou empatado!");
        }
    }
}