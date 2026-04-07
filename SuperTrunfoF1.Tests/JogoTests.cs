using System;
using SuperTrunfoF1.Enums;
using SuperTrunfoF1.Models;
using SuperTrunfoF1.Services;
using Xunit;

namespace SuperTrunfoF1.Tests
{
    public class JogoTests
    {
        [Fact]
        public void CompararCartas_DeveRetornar1_QuandoUsuarioVencerPorAtributo()
        {
            var jogo = new Jogo();

            var usuario = new Piloto("Piloto A", "Equipe A", 10, 20, 30, 5, 3);
            var computador = new Piloto("Piloto B", "Equipe B", 8, 15, 25, 4, 1);

            int resultado = jogo.CompararCartas(usuario, computador, Atributo.Titulos);

            Assert.Equal(1, resultado);
        }

        [Fact]
        public void CompararCartas_DeveRetornarMenos1_QuandoComputadorVencerPorAtributo()
        {
            var jogo = new Jogo();

            var usuario = new Piloto("Piloto A", "Equipe A", 10, 20, 30, 5, 1);
            var computador = new Piloto("Piloto B", "Equipe B", 8, 15, 25, 4, 3);

            int resultado = jogo.CompararCartas(usuario, computador, Atributo.Titulos);

            Assert.Equal(-1, resultado);
        }

        [Fact]
        public void CompararCartas_DeveRetornar0_QuandoHouverEmpate()
        {
            var jogo = new Jogo();

            var usuario = new Piloto("Piloto A", "Equipe A", 10, 20, 30, 5, 2);
            var computador = new Piloto("Piloto B", "Equipe B", 8, 15, 25, 4, 2);

            int resultado = jogo.CompararCartas(usuario, computador, Atributo.Titulos);

            Assert.Equal(0, resultado);
        }

        [Fact]
        public void CompararCartas_DeveRetornar1_QuandoUsuarioForSuperTrunfo()
        {
            var jogo = new Jogo();

            var usuario = new Piloto("Senna", "McLaren", 10, 41, 80, 65, 3, true);
            var computador = new Piloto("Hamilton", "Mercedes", 18, 103, 197, 104, 7);

            int resultado = jogo.CompararCartas(usuario, computador, Atributo.Titulos);

            Assert.Equal(1, resultado);
        }

        [Fact]
        public void CompararCartas_DeveRetornarMenos1_QuandoComputadorForSuperTrunfo()
        {
            var jogo = new Jogo();

            var usuario = new Piloto("Hamilton", "Mercedes", 18, 103, 197, 104, 7);
            var computador = new Piloto("Senna", "McLaren", 10, 41, 80, 65, 3, true);

            int resultado = jogo.CompararCartas(usuario, computador, Atributo.Titulos);

            Assert.Equal(-1, resultado);
        }

        [Fact]
        public void CompararCartas_DeveLancarExcecao_QuandoCartaUsuarioForNula()
        {
            var jogo = new Jogo();

            Piloto usuario = null!;
            var computador = new Piloto("Piloto B", "Equipe B", 8, 15, 25, 4, 3);

            Assert.Throws<ArgumentNullException>(() =>
                jogo.CompararCartas(usuario, computador, Atributo.Titulos));
        }
    }
}