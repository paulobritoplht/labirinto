namespace Labirinto
{
    public class Posicao
    {
        public Posicao(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public string RetornaPosicao()
        {
            return $"{X}-{Y}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Posicao other)
            {
                return this.X == other.X && this.Y == other.Y;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode(); // Combina os valores de X e Y
        }
    }
}
