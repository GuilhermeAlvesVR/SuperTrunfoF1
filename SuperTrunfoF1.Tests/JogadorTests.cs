using SuperTrunfoF1.Models;
using Xunit;

namespace SuperTrunfoF1.Tests
{
    public class JogadorTests
    {
        [Fact]
        public void Jogador_DeveIniciarComPontuacaoZero()
        {
            var jogador = new Jogador("Usuário");

            Assert.Equal(0, jogador.Pontuacao);
        }

        [Fact]
        public void AdicionarPonto_DeveIncrementarPontuacao()
        {
            var jogador = new Jogador("Usuário");

            jogador.AdicionarPonto();

            Assert.Equal(1, jogador.Pontuacao);
        }

        [Fact]
        public void Resetar_DeveZerarPontuacaoELimparCartas()
        {
            var jogador = new Jogador("Usuário");
            var piloto = new Piloto("Piloto A", "Equipe A", 10, 20, 30, 5, 1);

            jogador.AdicionarCarta(piloto);
            jogador.AdicionarPonto();

            jogador.Resetar();

            Assert.Equal(0, jogador.Pontuacao);
            Assert.Empty(jogador.Cartas);
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoNomeForVazio()
        {
            Assert.Throws<ArgumentException>(() => new Jogador(""));
        }

        [Fact]
        public void AdicionarCarta_DeveLancarExcecao_QuandoCartaForNula()
        {
            var jogador = new Jogador("Usuário");

            Assert.Throws<ArgumentNullException>(() => jogador.AdicionarCarta(null!));
        }
    }
}