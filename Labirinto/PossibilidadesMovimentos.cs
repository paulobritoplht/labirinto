using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinto
{
    public class PossibilidadesMovimentos
    {
        public bool ChegouNoDestino { get; set; }
        public required Posicao Posicao { get; set; }
        public required bool Esquerda { get; set; }
        public required bool Direita { get; set; }
        public required bool Cima { get; set; }
        public required bool Baixo { get; set; }
    }
}
