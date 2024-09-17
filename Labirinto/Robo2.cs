using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinto
{
    public class Robo2 : IRobo
    {
        private readonly IDictionary<Direcao, Direcao> caminhoVolta = new Dictionary<Direcao, Direcao>();
        public int JogadorId { get; }        
        private IList<Jogada> jogadas = new List<Jogada>();
        private PossibilidadesMovimentos possibilidades;


        public Robo2(int jogadorId)
        {
            this.JogadorId = jogadorId;

        }

        public void AdicionaPosicao(PossibilidadesMovimentos possibilidades)
        {
            this.possibilidades = possibilidades;
        }

        public Direcao ProximoMovimento()
        {            
            var direcoes = new List<Direcao>();

            if (possibilidades.Cima) 
            {
                direcoes.Add(Direcao.Cima);
            }

            if (possibilidades.Baixo)
            {
                direcoes.Add(Direcao.Baixo);
            }

            if (possibilidades.Esquerda)
            {
                direcoes.Add(Direcao.Esquerda);
            }

            if (possibilidades.Direita)
            {
                direcoes.Add(Direcao.Direita);
            }


            Random random = new Random();
            int indiceAleatorio = random.Next(direcoes.Count());
            
            return direcoes[indiceAleatorio];

        }

    }
}
