using System.Security.Policy;

namespace Labirinto
{
    public class Robo : IRobo
    {
        private readonly IDictionary<Direcao, Direcao> caminhoVolta = new Dictionary<Direcao, Direcao>();
        public int JogadorId { get; }
        private IList<Jogada> jogadas = new List<Jogada>();
        private Stack<Jogada> pilha = new Stack<Jogada>();
        private IList<Direcao> prioridadeJogadas = new List<Direcao> { Direcao.Direita, Direcao.Baixo, Direcao.Esquerda, Direcao.Cima };
        private bool empilharProximaJogada = true;
        private Direcao? direcaoSolicitada = null;
        private IList<Posicao> posicoesJaPecorridas { get; set; } = new List<Posicao>();
  



        public Robo(int jogadorId)
        {            
            this.JogadorId = jogadorId;


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

            if(posicoesJaPecorridas.Any(p => p.X == possibilidades.Posicao.X && p.Y == possibilidades.Posicao.Y)) 
            {
                foreach(var posicao in jogada.Posicoes) 
                {
                    posicao.Percorrida = true;
                }
            }
            else 
            {
                posicoesJaPecorridas.Add(possibilidades.Posicao);
            }

            
            pilha.Push(jogada);
        }

        public Direcao ProximoMovimento() 
        {
            var jogada = pilha.Peek();

            if (!jogada.Posicoes.Any(p => !p.Percorrida) && jogada.CaminhoVolta.HasValue)
            {
                pilha.Pop();
                empilharProximaJogada = false;
                return jogada.CaminhoVolta.Value;
            }

            foreach (var direcao in prioridadeJogadas)
            {
                var direcaoPercorrida = jogada.Posicoes.FirstOrDefault(p => p.Direcao == direcao && !p.Percorrida);
                if (direcaoPercorrida != null)
                {
                    direcaoPercorrida.Percorrida = true;
                    direcaoSolicitada = direcaoPercorrida.Direcao;
                    empilharProximaJogada = true;
                    return direcaoPercorrida.Direcao;                    
                }
            }

            throw new Exception("Não sei para onde ir");
        }

        

        
                
    }

    public class Jogada 
    {
        public Direcao? CaminhoVolta { get; set; }
        public Posicao Posicao;
        public IList<PosicaoPercorrida> Posicoes { get; set; } = new  List<PosicaoPercorrida>();
    }

    public class PosicaoPercorrida 
    {
        
        public Direcao Direcao { get; set; }
        public bool Percorrida { get; set; }        
    }

 
}

