using Labirinto.TemplateLabirintos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirinto
{
    public partial class CriarLabirinto : Form
    {
        private IList<Posicao> caminhoValido = new List<Posicao>();
        public CriarLabirinto()
        {
            
            InitializeComponent();
            panel1.AutoScroll = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int larguraBotao = 40;
            int alturaBotao = 40;
            int espacamento = 0; // Espaço entre os botões
            var numeroDeLinhas = Convert.ToInt32(txtLargura.Text);
            var numeroDeColunas = Convert.ToInt32(txtAltura.Text);

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
                    panel1.Controls.Add(botao);
                    botao.Name = $"{x}-{y}";
                    botao.Text = $"{x}-{y}";
                    //this.Controls.Add(botao);
                    botao.BackColor = Color.Black;
                    botao.Click += MarcarCaminho;
                }
            }
        }

        private void MarcarCaminho(object sender, EventArgs e)
        {
            var caminho = ((Button)sender);

            var nome = caminho.Name;
            var coordenadas = nome.Split('-');
            var x = Convert.ToInt32(coordenadas[0]);
            var y = Convert.ToInt32(coordenadas[1]);
            var posicao = new Posicao(x, y);

            if (caminho.BackColor ==  Color.Black)
            {

                caminhoValido.Add(posicao);
                caminho.BackColor = Color.White;
            }
            else
            {
                caminho.BackColor = Color.Black;

                var index = caminhoValido.IndexOf(posicao);
                caminhoValido.RemoveAt(index);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nome = txtNome.Text;
            var posicaoInicialText = txtPosicaoinicial.Text;

            var coordenadasIniciais = posicaoInicialText.Split('-');
            var inicialX = Convert.ToInt32(coordenadasIniciais[0]);
            var inicialY = Convert.ToInt32(coordenadasIniciais[1]);            

            var coordenadasFinais = txtPosicaoFinal.Text.Split('-');
            var finalX = Convert.ToInt32(coordenadasFinais[0]);
            var finalY = Convert.ToInt32(coordenadasFinais[1]);
            

            var posicaoFinalText = txtPosicaoFinal.Text;
            var numeroDeLinhas = Convert.ToInt32(txtLargura.Text);
            var numeroDeColunas = Convert.ToInt32(txtAltura.Text);

            var labirinto =
                new TemplateLabirintos.Labirinto(1, inicialX, inicialY, finalX, finalY, numeroDeColunas, numeroDeLinhas, caminhoValido);

            var json = System.Text.Json.JsonSerializer.Serialize(labirinto);
        
            var caminhoArquivo = $"C:\\Users\\Paulo\\Desktop\\Labirintos\\{nome}.json";
            System.IO.File.WriteAllText(caminhoArquivo, json);
            MessageBox.Show("Labirinto salvo em: " + caminhoArquivo);

        }
    }
}
