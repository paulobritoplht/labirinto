using Labirinto.TemplateLabirintos;

namespace Labirinto
{
    public class Servidor
    {
        public readonly LabirintoBase Labirinto;
        private IList<Jogador> jogadores = new List<Jogador>();
        public Servidor(LabirintoBase labirinto) 
        {
            this.Labirinto = labirinto;
        }

        public void AdicionarJogador(Jogador jogador) 
        {
            jogador.Posicao = new Posicao(Labirinto.PosicaoInicialX, Labirinto.PosicaoInicialy);
            jogadores.Add(jogador);
        }

        public string RecuperaPosicaoJogador(int jogadorId) 
        {
            var jogador = jogadores.First(j => j.Id == jogadorId);
            return jogador.Posicao.RetornaPosicao();
        }


        public PossibilidadesMovimentos Andar(int jogarId, Direcao direcao) 
        {
            switch (direcao) 
            {
                case Direcao.Direita:
                    AndarParaDireita(jogarId);
                    break;
                case Direcao.Esquerda:
                    AndarParaEsquerda(jogarId);
                    break;
                case Direcao.Cima:
                    AndarParaCima(jogarId);
                    break;
                case Direcao.Baixo:
                    AndarParaBaixo(jogarId);
                    break;
            }

            return RetornaPossibilidadesPosicao(jogarId);
        }

        public PossibilidadesMovimentos RetornaPossibilidadesPosicao(int jogadorId) 
        {
            var jogador = jogadores.First(j => j.Id == jogadorId);

            return new PossibilidadesMovimentos
            {
                Posicao = new Posicao(jogador.Posicao.X, jogador.Posicao.Y),
                Cima = PodeIrParaCima(jogador),
                Direita = PodeIrParaDireita(jogador),
                Baixo  = PodeIrParaBaixo(jogador),
                Esquerda  = PodeIrParaEsquerda(jogador),
                ChegouNoDestino = VerificaSeChegouNoDestino(jogador.Posicao)
            };
        }

        public void AndarParaDireita(int jogadorId)
        {
            var jogador = jogadores.First(j => j.Id == jogadorId);
            var x = jogador.Posicao.X + 1;

            if (PodeAndar(x, jogador.Posicao.Y))
            {
                jogador.Posicao.X = x;
            }            
        }

        public void AndarParaBaixo(int jogadorId)
        {
            var jogador = jogadores.First(j => j.Id == jogadorId);
            var y = jogador.Posicao.Y + 1;

            if (PodeAndar(jogador.Posicao.X, y))
            {
                jogador.Posicao.Y = y;
            }
        }

        public void AndarParaCima(int jogadorId)
        {
            var jogador = jogadores.First(j => j.Id == jogadorId);
            var y = jogador.Posicao.Y - 1;

            if (PodeAndar(jogador.Posicao.X, y))
            {
                jogador.Posicao.Y = y;
            }
        }

        public void AndarParaEsquerda(int jogadorId)
        {
            var jogador = jogadores.First(j => j.Id == jogadorId);
            var x = jogador.Posicao.X - 1;
            
            if(PodeAndar(x, jogador.Posicao.Y)) 
            {
                jogador.Posicao.X = x;
            }            
        }

        private bool PodeIrParaDireita(Jogador jogador)
        {            
            var posicao = new Posicao(jogador.Posicao.X + 1, jogador.Posicao.Y);
            return PodeAndar(posicao);
        }

        private bool PodeIrParaEsquerda(Jogador jogador)
        {            
            var posicao = new Posicao(jogador.Posicao.X - 1, jogador.Posicao.Y);
            return PodeAndar(posicao);
        }

        private bool PodeIrParaBaixo(Jogador jogador)
        {            
            var posicao = new Posicao(jogador.Posicao.X, jogador.Posicao.Y + 1);
            return PodeAndar(posicao);
        }

        private bool PodeIrParaCima(Jogador jogador)
        {            
            var posicao = new Posicao(jogador.Posicao.X, jogador.Posicao.Y - 1);
            return PodeAndar(posicao);
        }

        private bool PodeAndar(int x, int y)
        {
            return PodeAndar(new Posicao(x, y));
        }

        private bool PodeAndar(Posicao posicao)
        {
            return Labirinto.CaminhoValido().Any(l => l.RetornaPosicao() == posicao.RetornaPosicao());            
        }

        private bool VerificaSeChegouNoDestino(Posicao posicao) 
        {
            if (posicao.X == Labirinto.PosicaoFinallX && posicao.Y == Labirinto.PosicaoFinaly) 
            {
                return true;
            }

            return false;
        }


    }
}
