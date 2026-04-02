using System.Linq;
using SuperTrunfoF1.Services;
using Xunit;

namespace SuperTrunfoF1.Tests
{
    public class BaralhoTests
    {
        [Fact]
        public void Baralho_DeveCriar22Cartas()
        {
            var baralho = new Baralho();

            Assert.Equal(22, baralho.Cartas.Count);
        }

        [Fact]
        public void Baralho_DeveConterUmaCartaSuperTrunfo()
        {
            var baralho = new Baralho();

            int quantidadeSuperTrunfo = baralho.Cartas.Count(c => c.EhSuperTrunfo);

            Assert.Equal(1, quantidadeSuperTrunfo);
        }
    }
}