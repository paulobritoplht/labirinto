using Labirinto.TemplateLabirintos;
using System.Security.Policy;

namespace Labirinto
{
    public partial class Form1 : Form
    {
        private IList<Posicao> caminhoValido { get; set; } = new List<Posicao>();
        private IList<Button> labirinto { get; set; } = new List<Button>();
        private CaminhoLabirinto caminhoLabirinto; 
        public Form1()
        {
            InitializeComponent();

            caminhoValido = Labirintos.Labirinto1();
            caminhoLabirinto = new CaminhoLabirinto (new Posicao(caminhoValido.First().X, caminhoValido.First().Y), caminhoValido);            

            int larguraBotao = 10;
            int alturaBotao = 10;
            int espacamento = 0; // Espaço entre os botões
            int numeroDeColunas = 15;
            int numeroDeLinhas = 15; // Ajuste o número de linhas conforme necessário

            for (int x = 0; x < numeroDeLinhas; x++)
            {
                for (int y = 0; y < numeroDeColunas; y++)
                {
                    Button botao = new Button();
                    botao.Width = larguraBotao;
                    botao.Height = alturaBotao;
                    botao.Left = x * (alturaBotao + espacamento);
                    botao.Top = y * (larguraBotao + espacamento);

                    botao.FlatStyle = FlatStyle.Flat;
                    botao.FlatAppearance.BorderSize = 0;

                    //botao.Text = $"({y},{x})"; // Opcional: texto nos botões
                    botao.Name = $"{x}-{y}";
                    this.Controls.Add(botao); // Adiciona o botão ao formulário
                    labirinto.Add(botao);
                    botao.Click += CriarLabirinto_Click;

                    if (caminhoValido.Any(c => c.RetornaPosicao() == botao.Name))
                    {
                        botao.BackColor = Color.White;
                    }
                    else
                    {
                        botao.BackColor = Color.Black;
                    }
                }
            }

            var caminhoInicial = labirinto.First(l => l.Name == caminhoValido.First().RetornaPosicao());
            caminhoInicial.BackColor = Color.Green;
            AvisaProximosPassos();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CriarLabirinto_Click(object sender, EventArgs e)
        {
            var botao = (Button)sender;

            var posicaoXY = botao.Name.Split("-");

            caminhoValido.Add(new Posicao(Convert.ToInt32(posicaoXY[0]), Convert.ToInt32(posicaoXY[1])));

            botao.BackColor = Color.White;
        }

        private void AntarParaDireita_Click(object sender, EventArgs e)
        {
            var x = caminhoLabirinto.PosicaoAtual.X + 1;
            Andar(x, caminhoLabirinto.PosicaoAtual.Y);
        }

        private void AndarParaEsquerda_Click(object sender, EventArgs e)
        {
            var x = caminhoLabirinto.PosicaoAtual.X - 1;
            Andar(x, caminhoLabirinto.PosicaoAtual.Y);
        }

        private void AndarParaBaixo_Click(object sender, EventArgs e)
        {
            var y = caminhoLabirinto.PosicaoAtual.Y + 1;
            Andar(caminhoLabirinto.PosicaoAtual.X, y);
        }

        private void AndarParaCima_Click(object sender, EventArgs e)
        {
            var y = caminhoLabirinto.PosicaoAtual.Y - 1;
            Andar(caminhoLabirinto.PosicaoAtual.X, y);
        }

        private void Andar(int x, int y)
        {
            if (caminhoValido.Any(l => l.RetornaPosicao() == $"{x}-{y}"))
            {
                foreach (var caminhoLabirinto in labirinto)
                {
                    if (caminhoLabirinto.BackColor != Color.Black)
                    {
                        caminhoLabirinto.BackColor = Color.White;
                    }
                }

                var caminho = labirinto.First(l => l.Name == $"{x}-{y}");
                caminho.BackColor = Color.Green;
                caminhoLabirinto.PosicaoAtual.X = x;
                caminhoLabirinto.PosicaoAtual.Y = y;

                AvisaProximosPassos();
            }
        }

        private void AvisaProximosPassos()
        {
            ProximosCaminhos.Text = $"{ System.Text.Json.JsonSerializer.Serialize(caminhoLabirinto.RecuperarPossibilidadeMovimentos())}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach(var botao in labirinto) 
            {
                botao.BackColor = Color.Black;
            }
        }
    }

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

    public class CaminhoLabirinto 
    {
        public CaminhoLabirinto(Posicao posicaoAtual, IList<Posicao> caminhoValido)
        {
            PosicaoAtual = posicaoAtual;
            CaminhoValido = caminhoValido;            
        }

        public Posicao PosicaoAtual { get; set; }
        public IList<Posicao> CaminhoValido { get; set; }

        public PossibilidadesMovimentos RecuperarPossibilidadeMovimentos() 
        {
            return new PossibilidadesMovimentos
            {
                Esquerda = PodeIrParaEsquerda(),
                Baixo = PodeIrParaBaixo(),
                Cima = PodeIrParaCima(),
                Direita = PodeIrParaDireita()
            };
        }

        private bool PodeIrParaDireita() 
        {
            var posicao = new Posicao(PosicaoAtual.X + 1, PosicaoAtual.Y);
            return VerificaPosicao(posicao);
        }

        private bool PodeIrParaEsquerda()
        {
            var posicao = new Posicao(PosicaoAtual.X - 1, PosicaoAtual.Y);
            return VerificaPosicao(posicao);
        }

        private bool PodeIrParaBaixo()
        {
            var posicao = new Posicao(PosicaoAtual.X, PosicaoAtual.Y + 1);
            return VerificaPosicao(posicao);
        }

        private bool PodeIrParaCima()
        {
            var posicao = new Posicao(PosicaoAtual.X, PosicaoAtual.Y - 1);
            return VerificaPosicao(posicao);
        }

        private bool VerificaPosicao(Posicao posicao) 
        {
            return CaminhoValido.Any(c => c.RetornaPosicao() == posicao.RetornaPosicao());
        }
    }

    public class PossibilidadesMovimentos 
    {
        public bool ChegouNoDestino { get; set; }
        public Posicao Posicao { get; set; }
        public required bool Esquerda { get; set; }
        public required bool Direita { get; set; }
        public required bool Cima { get; set; }
        public required bool Baixo { get; set; }
    }
}
