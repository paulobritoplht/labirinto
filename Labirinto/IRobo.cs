namespace Labirinto
{
    public interface IRobo
    {
        public int JogadorId { get; }
        Direcao ProximoMovimento();
        void AdicionaPosicao(PossibilidadesMovimentos possibilidades);
    }
}
