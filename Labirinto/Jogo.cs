using System.Data;

namespace Labirinto
{
    public partial class Jogo : Form
    {
        public Servidor Servidor;
        private IList<Button> labirinto { get; set; } = new List<Button>();
        private IList<IRobo> jogadores { get; set; } = new List<IRobo>();
        private IDictionary<int, Color> coresJogado = new Dictionary<int, Color>();
        public IList<ControleJogador> controleJogador = new List<ControleJogador>();    
        public Jogo()
        {
            var caminhoArquivo = @$"C:\Users\paulo.brito\source\repos\paulobritoplht\labirinto\Labirintos\teste45.json";
            
            var json = System.IO.File.ReadAllText(caminhoArquivo);

            // Desserializa o JSON para o objeto Labirinto
            var labirintoMapa = System.Text.Json.JsonSerializer.Deserialize<TemplateLabirintos.Labirinto>(json);

            var mapa1 = new TemplateLabirintos.LabirintoNivel1();
           

            //Servidor = new Servidor(new TemplateLabirintos.LabirintoNivel1());
            Servidor = new Servidor(labirintoMapa);

    


            jogadores.Add(new Robo(1));
            //jogadores.Add(new Robo2(2));
            //jogadores.Add(new Robo2(3, Servidor));
            //jogadores.Add(new Robo2(4, Servidor));
            //jogadores.Add(new Robo2(5, Servidor));
            //jogadores.Add(new Robo2(6, Servidor));
            //jogadores.Add(new Robo2(7, Servidor));
            //jogadores.Add(new Robo2(8, Servidor));
            //jogadores.Add(new Robo2(9, Servidor));


            foreach (var jogador in jogadores)
            {
                Servidor.AdicionarJogador(new Jogador { Id = jogador.JogadorId });
                jogador.AdicionaPosicao(Servidor.RetornaPossibilidadesPosicao(jogador.JogadorId));
            }

            coresJogado.Add(1, Color.Blue);
            coresJogado.Add(2, Color.Green);
            coresJogado.Add(3, Color.Yellow);
            coresJogado.Add(4, Color.Orange);
            coresJogado.Add(5, Color.Brown);
            coresJogado.Add(6, Color.Purple);
            coresJogado.Add(7, Color.Gray);
            coresJogado.Add(8, Color.AntiqueWhite);
            coresJogado.Add(9, Color.AliceBlue);

            int larguraBotao = 15;
            int alturaBotao = 15;
            int espacamento = 0; // Espaço entre os botões
            int numeroDeColunas = Servidor.Labirinto.QuantidadeColunas;
            int numeroDeLinhas = Servidor.Labirinto.QuantidadeLinhas; // Ajuste o número de linhas conforme necessário

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

                    botao.Name = $"{x}-{y}";
                    this.Controls.Add(botao);
                    labirinto.Add(botao);

                    if (Servidor.Labirinto.CaminhoValido().Any(c => c.RetornaPosicao() == botao.Name))
                    {
                        botao.BackColor = Color.White;
                    }
                    else
                    {
                        botao.BackColor = Color.Black;
                    }
                }
            }

            var caminhoInicial = labirinto.First(l => l.Name == Servidor.Labirinto.CaminhoValido().First().RetornaPosicao());
            caminhoInicial.BackColor = Color.Green;

            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {


            Acao();



        }

        private async void Acao()
        {
            for (var i = 0; i < 300; i++)
            {
                foreach (var robo in jogadores)
                {
                    if(controleJogador.Any(f => f.JogadorId == robo.JogadorId && f.Chegou)) 
                    {
                        continue;
                    }

                    try 
                    {
                        var direcao = robo.ProximoMovimento();
                        var direcoesDisponiveis = Servidor.Andar(robo.JogadorId, direcao);
                        robo.AdicionaPosicao(direcoesDisponiveis);
                        var posicao = Servidor.RecuperaPosicaoJogador(robo.JogadorId);
                        MoverJogador(robo, posicao);

                  
                        if (direcoesDisponiveis.ChegouNoDestino) 
                        {
                            controleJogador.First(f => f.JogadorId == robo.JogadorId).Chegou = true;
                        }
                       
                    } 
                    catch 
                    {
                        //controleJogador.First(f => f.JogadorId == robo.JogadorId).Observacao = "LOST";
                    }

                    //controleJogador.First(f => f.JogadorId == robo.JogadorId).Passos++;

                    await Task.Delay(50);

                }
            }
        }

        private void MoverJogador(IRobo robo, string posicao) 
        {
            //var caminho = labirinto.First(c => c.BackColor.ToString() == coresJogado[robo.JogadorId].ToString());
            //caminho.BackColor = Color.White;

            foreach (var caminho in labirinto.Where(c => c.BackColor.ToString() == coresJogado[robo.JogadorId].ToString()))
            {
                caminho.BackColor = Color.White;
            }

            var caminhoJogador = labirinto.First(c => c.Name == posicao);
            caminhoJogador.BackColor = coresJogado[robo.JogadorId];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Instancia o novo formulário
            CriarLabirinto criarLabirinto = new CriarLabirinto();

            // Exibe o novo formulário
            criarLabirinto.Show();

            // Para ocultar o formulário atual (opcional)
            this.Hide();
        }
    }

    public enum Direcao
    {
        Esquerda = 1,
        Direita = 2,
        Baixo = 3,
        Cima = 4
    }

    public class ControleJogador 
    {
        public int JogadorId { get; set; }
        public bool Chegou { get; set; }
        public int Passos { get; set; }
        public string? Observacao { get; set; }
    }

    public class JogadorPartida 
    {
        public IRobo Jogador { get; set; }
        public int QuantidadePassos { get; set; }
        public bool Chegou { get; set; }
        public string? Observacao { get; set; }
    }
}
