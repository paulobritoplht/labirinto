﻿namespace Labirinto.TemplateLabirintos
{
    public class LabirintoNivel1 //: LabirintoBase
    {
        public int Id => 1;

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
                new Posicao(1, 1),

                new Posicao(1, 11),
                new Posicao(1, 12),

                new Posicao(11, 1),
                new Posicao(12, 1),
                new Posicao(13, 1),
                new Posicao(14, 1),



                new Posicao(1, 0),
                new Posicao(2, 0),
                new Posicao(2, 1),                
                new Posicao(1, 0),
                new Posicao(2, 0),
                new Posicao(2, 1),
                new Posicao(2, 2),
                new Posicao(3, 2),
                new Posicao(4, 2),
                new Posicao(5, 2),
                new Posicao(6, 2),
                new Posicao(7, 2),
                new Posicao(8, 2),
                new Posicao(8, 3),
                new Posicao(8, 4),
                new Posicao(8, 5),
                new Posicao(7, 5),
                new Posicao(6, 5),
                new Posicao(5, 5),
                new Posicao(5, 4),
                new Posicao(4, 4),
                new Posicao(3, 4),
                new Posicao(2, 4),
                new Posicao(2, 5),
                new Posicao(2, 6),
                new Posicao(2, 7),
                new Posicao(2, 8),
                new Posicao(2, 9),
                new Posicao(2, 10),
                new Posicao(3, 10),
                new Posicao(4, 10),
                new Posicao(5, 10),
                new Posicao(6, 10),
                new Posicao(7, 10),
                new Posicao(7, 9),
                new Posicao(7, 8),
                new Posicao(8, 8),
                new Posicao(9, 8),
                new Posicao(10, 8),
                new Posicao(10, 9),
                new Posicao(10, 10),
                new Posicao(10, 11),
                new Posicao(10, 12),
                new Posicao(9, 12),
                new Posicao(8, 12),
                new Posicao(7, 12),
                new Posicao(7, 13),
                new Posicao(5, 13),
                new Posicao(4, 13),
                new Posicao(6, 13),
                new Posicao(4, 14),
                new Posicao(3, 0),
                new Posicao(4, 0),
                new Posicao(5, 0),
                new Posicao(6, 0),
                new Posicao(7, 0),
                new Posicao(8, 0),
                new Posicao(9, 0),
                new Posicao(10, 0),
                new Posicao(11, 0),
                new Posicao(12, 0),
                new Posicao(12, 1),
                new Posicao(12, 2),
                new Posicao(12, 3),
                new Posicao(13, 1),
                new Posicao(14, 1),
                new Posicao(13, 3),
                new Posicao(13, 4),
                new Posicao(13, 5),
                new Posicao(14, 5),
                new Posicao(11, 3),
                new Posicao(10, 3),
                new Posicao(1, 5),
                new Posicao(0, 5),
                new Posicao(3, 7),
                new Posicao(4, 7),
                new Posicao(4, 8),
                new Posicao(1, 9),
                new Posicao(0, 9),
                new Posicao(2, 11),
                new Posicao(2, 12),
                new Posicao(1, 12),
                new Posicao(10, 7),
                new Posicao(10, 6),
                new Posicao(11, 8),
                new Posicao(12, 8),
                new Posicao(13, 8),
                new Posicao(13, 10),
                new Posicao(11, 11),
                new Posicao(12, 11),
                new Posicao(10, 13),
                new Posicao(11, 13),
                new Posicao(12, 13),
                new Posicao(13, 13)
            };

            return caminhoValido;
        }
    }
}
