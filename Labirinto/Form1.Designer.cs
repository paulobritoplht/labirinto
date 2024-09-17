namespace Labirinto
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ProximosCaminhos = new TextBox();
            button5 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1120, 44);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Direita";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AntarParaDireita_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1039, 44);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Esquerda";
            button2.UseVisualStyleBackColor = true;
            button2.Click += AndarParaEsquerda_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1078, 73);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "Baixo";
            button3.UseVisualStyleBackColor = true;
            button3.Click += AndarParaBaixo_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1078, 15);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 3;
            button4.Text = "Cima";
            button4.UseVisualStyleBackColor = true;
            button4.Click += AndarParaCima_Click;
            // 
            // ProximosCaminhos
            // 
            ProximosCaminhos.Location = new Point(871, 136);
            ProximosCaminhos.Name = "ProximosCaminhos";
            ProximosCaminhos.Size = new Size(324, 23);
            ProximosCaminhos.TabIndex = 4;
            // 
            // button5
            // 
            button5.Location = new Point(1051, 211);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 5;
            button5.Text = "Baixo";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1197, 450);
            Controls.Add(button5);
            Controls.Add(ProximosCaminhos);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox ProximosCaminhos;
        private Button button5;
    }
}
