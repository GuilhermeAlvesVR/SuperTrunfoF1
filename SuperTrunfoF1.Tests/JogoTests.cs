using SuperTrunfoF1.Enums;
using SuperTrunfoF1.Models;
using SuperTrunfoF1.Services;
using Xunit;

namespace SuperTrunfoF1.Tests
{
    public class JogoTests
    {
        [Fact]
        public void CompararCartas_DeveRetornar1_QuandoUsuarioTemMaiorAtributo()
        {
            Jogo jogo = new Jogo();

            Piloto usuario = new Piloto("Piloto A", "Equipe A", 10, 50, 100, 20, 2);
            Piloto computador = new Piloto("Piloto B", "Equipe B", 8, 20, 50, 10, 1);

            int resultado = jogo.CompararCartas(usuario, computador, Atributo.Vitorias);

            Assert.Equal(1, resultado);
        }

        [Fact]
        public void CompararCartas_DeveRetornarMenos1_QuandoComputadorTemMaiorAtributo()
        {
            Jogo jogo = new Jogo();

            Piloto usuario = new Piloto("Piloto A", "Equipe A", 10, 10, 100, 20, 2);
            Piloto computador = new Piloto("Piloto B", "Equipe B", 8, 20, 50, 10, 1);

            int resultado = jogo.CompararCartas(usuario, computador, Atributo.Vitorias);

            Assert.Equal(-1, resultado);
        }

        [Fact]
        public void CompararCartas_DeveRetornar0_QuandoHouverEmpate()
        {
            Jogo jogo = new Jogo();

            Piloto usuario = new Piloto("Piloto A", "Equipe A", 10, 20, 100, 20, 2);
            Piloto computador = new Piloto("Piloto B", "Equipe B", 8, 20, 50, 10, 1);

            int resultado = jogo.CompararCartas(usuario, computador, Atributo.Vitorias);

            Assert.Equal(0, resultado);
        }

        [Fact]
        public void CompararCartas_DeveRetornar1_QuandoUsuarioForSuperTrunfo()
        {
            Jogo jogo = new Jogo();

            Piloto usuario = new Piloto("Senna", "Lenda", 10, 41, 80, 65, 3, true);
            Piloto computador = new Piloto("Piloto B", "Equipe B", 8, 20, 50, 10, 1);

            int resultado = jogo.CompararCartas(usuario, computador, Atributo.Vitorias);

            Assert.Equal(1, resultado);
        }

        [Fact]
        public void CompararCartas_DeveRetornarMenos1_QuandoComputadorForSuperTrunfo()
        {
            Jogo jogo = new Jogo();

            Piloto usuario = new Piloto("Piloto A", "Equipe A", 10, 20, 100, 20, 2);
            Piloto computador = new Piloto("Senna", "Lenda", 10, 41, 80, 65, 3, true);

            int resultado = jogo.CompararCartas(usuario, computador, Atributo.Vitorias);

            Assert.Equal(-1, resultado);
        }

        [Fact]
        public void CompararCartas_DeveRetornar0_QuandoAmbosForemSuperTrunfo()
        {
            Jogo jogo = new Jogo();

            Piloto usuario = new Piloto("Senna 1", "Lenda", 10, 41, 80, 65, 3, true);
            Piloto computador = new Piloto("Senna 2", "Lenda", 10, 41, 80, 65, 3, true);

            int resultado = jogo.CompararCartas(usuario, computador, Atributo.Vitorias);

            Assert.Equal(0, resultado);
        }

        [Fact]
        public void CompararCartas_DeveLancarExcecao_QuandoCartaUsuarioForNula()
        {
            Jogo jogo = new Jogo();

            Piloto computador = new Piloto("Piloto B", "Equipe B", 8, 20, 50, 10, 1);

            Assert.Throws<ArgumentNullException>(() =>
                jogo.CompararCartas(null!, computador, Atributo.Vitorias));
        }

        [Fact]
        public void CompararCartas_DeveLancarExcecao_QuandoCartaComputadorForNula()
        {
            Jogo jogo = new Jogo();

            Piloto usuario = new Piloto("Piloto A", "Equipe A", 10, 20, 100, 20, 2);

            Assert.Throws<ArgumentNullException>(() =>
                jogo.CompararCartas(usuario, null!, Atributo.Vitorias));
        }
    }
}
