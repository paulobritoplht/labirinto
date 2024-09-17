using System.Security.Cryptography.X509Certificates;

namespace Labirinto.TemplateLabirintos
{
    public interface LabirintoBase
    {
        public int Id { get; }
        public int PosicaoInicialX { get; }
        public int PosicaoFinallX { get; }
        public int PosicaoInicialy { get; }
        public int PosicaoFinaly { get; }
        public int QuantidadeColunas { get; }
        public int QuantidadeLinhas { get; }
        public IList<Posicao> CaminhoValido();
        
    }

    public class Labirinto : LabirintoBase
    {
        public int Id { get; }
        public int PosicaoInicialX { get; }
        public int PosicaoFinallX { get; }
        public int PosicaoInicialy { get; }
        public int PosicaoFinaly { get; }

        public int QuantidadeColunas { get; }
        public int QuantidadeLinhas { get; }
        public IList<Posicao> caminhoValido { get; }
        public IList<Posicao> CaminhoValido()
        {
            return caminhoValido;
        }
        public Labirinto(
            int id,
            int posicaoInicialX,
            int posicaoFinallX, 
            int posicaoInicialy,
            int posicaoFinaly,
            int quantidadeColunas, 
            int quantidadeLinhas,
            IList<Posicao> caminhoValido)
        {
            Id = id;
            PosicaoInicialX = posicaoInicialX;
            PosicaoFinallX = posicaoFinallX;
            PosicaoInicialy = posicaoInicialy;
            PosicaoFinaly = posicaoFinaly;
            QuantidadeColunas = quantidadeColunas;
            QuantidadeLinhas = quantidadeLinhas;
            this.caminhoValido = caminhoValido;

        }

    }
}
