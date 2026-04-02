using SuperTrunfoF1.Services;

namespace SuperTrunfoF1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Jogo jogo = new Jogo();
                    jogo.Iniciar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro ao executar o jogo.");
                    Console.WriteLine($"Detalhes: {ex.Message}");
                }

                Console.WriteLine("\nDeseja jogar novamente? (S/N): ");

            } while (Console.ReadLine()?.Trim().ToUpper() == "S");

            Console.WriteLine("\nObrigado por jogar! Pressione qualquer tecla para encerrar...");
            Console.ReadKey();
        }
    }
}