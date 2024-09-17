using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinto
{
    internal class Robo3 : IRobo
    {
        private readonly IDictionary<Direcao, Direcao> caminhoVolta = new Dictionary<Direcao, Direcao>();
        public int JogadorId { get; }
        private readonly Servidor servidor;
        private IList<Jogada> jogadas = new List<Jogada>();
        private Stack<Jogada> pilha = new Stack<Jogada>();
        private IList<Direcao> prioridadeJogadas = new List<Direcao> { Direcao.Direita, Direcao.Baixo, Direcao.Esquerda, Direcao.Cima };
        private bool empilharProximaJogada = true;
        private Direcao? direcaoSolicitada = null;

        public Robo3(int jogadorId, Servidor servidor)
        {
            this.JogadorId = jogadorId;
            this.servidor = servidor;

            caminhoVolta.Add(Direcao.Direita, Direcao.Esquerda);
            caminhoVolta.Add(Direcao.Esquerda, Direcao.Direita);
            caminhoVolta.Add(Direcao.Cima, Direcao.Baixo);
            caminhoVolta.Add(Direcao.Baixo, Direcao.Cima);
        }

        public void AdicionaPosicao(PossibilidadesMovimentos possibilidades)
        {

            if (!empilharProximaJogada)
            {
                return;
            }

            var jogada = new Jogada();
            jogada.Posicao = possibilidades.Posicao;

            if (possibilidades.Esquerda)
            {
                jogada.Posicoes.Add(new PosicaoPercorrida { Direcao = Direcao.Esquerda, Percorrida = false });
            }

            if (possibilidades.Direita)
            {
                jogada.Posicoes.Add(new PosicaoPercorrida { Direcao = Direcao.Direita, Percorrida = false });
            }

            if (possibilidades.Cima)
            {
                jogada.Posicoes.Add(new PosicaoPercorrida { Direcao = Direcao.Cima, Percorrida = false });
            }

            if (possibilidades.Baixo)
            {
                jogada.Posicoes.Add(new PosicaoPercorrida { Direcao = Direcao.Baixo, Percorrida = false });
            }

            jogadas.Add(jogada);

            if (direcaoSolicitada.HasValue)
            {
                jogada.CaminhoVolta = caminhoVolta[direcaoSolicitada.Value];
                jogada.Posicoes.First(p => p.Direcao == jogada.CaminhoVolta).Percorrida = true;
            }

            pilha.Push(jogada);
        }

        public Direcao ProximoMovimento()
        {
            var jogada = pilha.Peek();



            var direcaoPercorrida = jogada.Posicoes.FirstOrDefault(p => !p.Percorrida);
            Random random = new Random();
            int indiceAleatorio = random.Next(jogada.Posicoes.Count());

            return jogada.Posicoes[indiceAleatorio].Direcao;

        }

        public void Jogar()
        {
            var jogada = pilha.Peek();

            if (!jogada.Posicoes.Any(p => !p.Percorrida) && jogada.CaminhoVolta.HasValue)
            {
                servidor.Andar(JogadorId, jogada.CaminhoVolta.Value);
                pilha.Pop();
            }

            jogada = pilha.Peek();

            var direcaoPercorrida = jogada.Posicoes.FirstOrDefault(p => !p.Percorrida);

            if (direcaoPercorrida != null)
            {
                var possibilidade = servidor.Andar(JogadorId, direcaoPercorrida.Direcao);
                direcaoPercorrida.Percorrida = true;
                direcaoSolicitada = direcaoPercorrida.Direcao;
                //AdicionaJogada(possibilidade, direcaoPercorrida.Direcao);

                return;
            }

            //jogadas.RemoveAt(jogadas.Count() - 1);

        }

        private Jogada RetornaJogada()
        {
            var jogada = pilha.Peek();

            if (!jogada.Posicoes.Any(p => p.Percorrida))
            {
                pilha.Pop();
            }

            jogada = pilha.Peek();

            return jogada;
        }


        public void Jogar3()
        {
            var jogada = jogadas.Last(j => j.Posicoes.Any(p => !p.Percorrida));

            foreach (var direcao in prioridadeJogadas)
            {
                var direcaoPercorrida = jogada.Posicoes.FirstOrDefault(p => p.Direcao == direcao && !p.Percorrida);
                if (direcaoPercorrida != null)
                {
                    var possibilidade = servidor.Andar(JogadorId, direcaoPercorrida.Direcao);
                    direcaoPercorrida.Percorrida = true;

                    if (!jogadas.Any(j => j.Posicao.RetornaPosicao() == possibilidade.Posicao.RetornaPosicao()))
                    {
                        AdicionaPosicao(possibilidade);
                    }

                    return;
                }
            }

            //jogadas.RemoveAt(jogadas.Count() - 1);

        }


    }
}
