namespace Labirinto
{
    partial class CriarLabirinto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLargura = new TextBox();
            txtAltura = new TextBox();
            button1 = new Button();
            button2 = new Button();
            txtNome = new TextBox();
            txtPosicaoinicial = new TextBox();
            txtPosicaoFinal = new TextBox();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // txtLargura
            // 
            txtLargura.Location = new Point(1221, 7);
            txtLargura.Name = "txtLargura";
            txtLargura.Size = new Size(100, 23);
            txtLargura.TabIndex = 0;
            // 
            // txtAltura
            // 
            txtAltura.Location = new Point(1221, 36);
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(100, 23);
            txtAltura.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(1217, 81);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1217, 254);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(1217, 124);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 4;
            txtNome.Text = "Nome";
            // 
            // txtPosicaoinicial
            // 
            txtPosicaoinicial.Location = new Point(1217, 153);
            txtPosicaoinicial.Name = "txtPosicaoinicial";
            txtPosicaoinicial.Size = new Size(100, 23);
            txtPosicaoinicial.TabIndex = 5;
            // 
            // txtPosicaoFinal
            // 
            txtPosicaoFinal.Location = new Point(1217, 182);
            txtPosicaoFinal.Name = "txtPosicaoFinal";
            txtPosicaoFinal.Size = new Size(100, 23);
            txtPosicaoFinal.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Location = new Point(3, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(1146, 540);
            panel1.TabIndex = 7;
            // 
            // CriarLabirinto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1324, 549);
            Controls.Add(panel1);
            Controls.Add(txtPosicaoFinal);
            Controls.Add(txtPosicaoinicial);
            Controls.Add(txtNome);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtAltura);
            Controls.Add(txtLargura);
            Name = "CriarLabirinto";
            Text = "CriarLabirinto";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLargura;
        private TextBox txtAltura;
        private Button button1;
        private Button button2;
        private TextBox txtNome;
        private TextBox txtPosicaoinicial;
        private TextBox txtPosicaoFinal;
        private Panel panel1;
    }
}