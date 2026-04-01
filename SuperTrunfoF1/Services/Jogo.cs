using SuperTrunfoF1.Enums;
using SuperTrunfoF1.Models;

namespace SuperTrunfoF1.Services
{
    public class Jogo
    {
        public Jogador Usuario { get; private set; }
        public Jogador Computador { get; private set; }
        public Baralho Baralho { get; private set; }

        public Jogo()
        {
            Usuario = new Jogador("Usuário");
            Computador = new Jogador("Computador");
            Baralho = new Baralho();
        }

        public void Iniciar()
        {
            ReiniciarEstadoDoJogo();

            if (Baralho == null || Baralho.Cartas == null || Baralho.Cartas.Count == 0)
                throw new InvalidOperationException("O baralho não foi inicializado corretamente.");

            Baralho.Embaralhar();
            DistribuirCartas();

            if (Usuario.Cartas.Count != Computador.Cartas.Count)
                throw new InvalidOperationException("A distribuição de cartas ficou desigual.");

            JogarRodadas();
            ExibirResultadoFinal();
        }

        private void ReiniciarEstadoDoJogo()
        {
            Usuario.Resetar();
            Computador.Resetar();
        }

        private void DistribuirCartas()
        {
            if (Baralho == null || Baralho.Cartas == null)
                throw new InvalidOperationException("Baralho inválido.");

            if (Baralho.Cartas.Count < 2)
                throw new InvalidOperationException("Não há cartas suficientes para iniciar o jogo.");

            for (int i = 0; i < Baralho.Cartas.Count; i++)
            {
                if (i % 2 == 0)
                    Usuario.AdicionarCarta(Baralho.Cartas[i]);
                else
                    Computador.AdicionarCarta(Baralho.Cartas[i]);
            }
        }

        private void JogarRodadas()
        {
            if (Usuario.Cartas.Count == 0 || Computador.Cartas.Count == 0)
                throw new InvalidOperationException("Os jogadores não possuem cartas para jogar.");

            if (Usuario.Cartas.Count != Computador.Cartas.Count)
                throw new InvalidOperationException("Os jogadores possuem quantidades diferentes de cartas.");

            int totalRodadas = Usuario.Cartas.Count;

            for (int i = 0; i < totalRodadas; i++)
            {
                Console.Clear();
                Console.WriteLine($"========== RODADA {i + 1} ==========\n");

                Piloto cartaUsuario = Usuario.Cartas[i];
                Piloto cartaComputador = Computador.Cartas[i];

                if (cartaUsuario == null || cartaComputador == null)
                    throw new InvalidOperationException("Foi encontrada uma carta nula durante a rodada.");

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
                    Usuario.AdicionarPonto();
                }
                else if (resultado < 0)
                {
                    Console.WriteLine("\nO computador venceu a rodada!");
                    Computador.AdicionarPonto();
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

                string entrada = Console.ReadLine() ?? "";

                switch (entrada)
                {
                    case "1": return Atributo.Experiencia;
                    case "2": return Atributo.Vitorias;
                    case "3": return Atributo.Podios;
                    case "4": return Atributo.PolePositions;
                    case "5": return Atributo.Titulos;
                    default:
                        Console.WriteLine("\nOpção inválida. Tente novamente.");
                        break;
                }
            }
        }

        public int CompararCartas(Piloto usuario, Piloto computador, Atributo atributo)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "A carta do usuário não pode ser nula.");

            if (computador == null)
                throw new ArgumentNullException(nameof(computador), "A carta do computador não pode ser nula.");

            if (usuario.EhSuperTrunfo && computador.EhSuperTrunfo)
                return 0;

            if (usuario.EhSuperTrunfo)
                return 1;

            if (computador.EhSuperTrunfo)
                return -1;

            int valorUsuario = usuario.ObterValorAtributo(atributo);
            int valorComputador = computador.ObterValorAtributo(atributo);

            return valorUsuario.CompareTo(valorComputador);
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