using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinto.TemplateLabirintos
{
    public class LabirintoTudoAberto //: LabirintoBase
    {
        public int Id => 2;

        public Posicao PosicaoInicial { get => new Posicao(0, 0); }
        public Posicao PosicaoFinal { get => new Posicao(4, 14); }

        public int QuantidadeColunas => 15;

        public int QuantidadeLinhas => 15;

        public IList<Posicao> CaminhoValido()
        {
            var caminhoValido = new List<Posicao>
            {
                new Posicao(0, 0),
                new Posicao(0, 1),
                new Posicao(0, 2),
                new Posicao(0, 3),
                new Posicao(0, 4),

                new Posicao(1, 0),
                new Posicao(1, 1),
                new Posicao(1, 2),
                new Posicao(1, 3),
                new Posicao(1, 4),

                new Posicao(2, 1),
                new Posicao(2, 0),
                new Posicao(2, 2),
                new Posicao(2, 3),
                new Posicao(2, 4),

                new Posicao(3, 1),
                new Posicao(3, 0),
                new Posicao(3, 2),
                new Posicao(3, 3),
                new Posicao(3, 4),

                new Posicao(4, 1),
                new Posicao(4, 0),
                new Posicao(4, 2),
                new Posicao(4, 3),
                new Posicao(4, 4),



            };

            return caminhoValido;
        }
    }
}
