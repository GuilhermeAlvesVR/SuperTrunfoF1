using SuperTrunfoF1.Enums;
using SuperTrunfoF1.Models;
using Xunit;

namespace SuperTrunfoF1.Tests
{
    public class PilotoTests
    {
        [Fact]
        public void ObterValorAtributo_DeveRetornarExperienciaCorretamente()
        {
            var piloto = new Piloto("Piloto A", "Equipe A", 10, 20, 30, 5, 1);

            int valor = piloto.ObterValorAtributo(Atributo.Experiencia);

            Assert.Equal(10, valor);
        }

        [Fact]
        public void ObterValorAtributo_DeveRetornarVitoriasCorretamente()
        {
            var piloto = new Piloto("Piloto A", "Equipe A", 10, 20, 30, 5, 1);

            int valor = piloto.ObterValorAtributo(Atributo.Vitorias);

            Assert.Equal(20, valor);
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoNomeForVazio()
        {
            Assert.Throws<ArgumentException>(() =>
                new Piloto("", "Equipe A", 10, 20, 30, 5, 1));
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoEquipeForVazia()
        {
            Assert.Throws<ArgumentException>(() =>
                new Piloto("Piloto A", "", 10, 20, 30, 5, 1));
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_QuandoAtributoForNegativo()
        {
            Assert.Throws<ArgumentException>(() =>
                new Piloto("Piloto A", "Equipe A", -1, 20, 30, 5, 1));
        }

        [Fact]
        public void ObterValorAtributo_DeveLancarExcecao_QuandoAtributoForInvalido()
        {
            var piloto = new Piloto("Piloto A", "Equipe A", 10, 20, 30, 5, 1);

            Assert.Throws<ArgumentException>(() =>
                piloto.ObterValorAtributo((Atributo)999));
        }
    }
}   