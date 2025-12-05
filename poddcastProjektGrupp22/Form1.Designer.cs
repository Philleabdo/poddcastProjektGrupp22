namespace poddcastProjektGrupp22
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
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            radera_kategori = new Button();
            label2 = new Label();
            label3 = new Label();
            comboBoxKategori = new ComboBox();
            textBoxURL = new TextBox();
            buttonSpara = new Button();
            label1 = new Label();
            listBoxLankar = new ListBox();
            listBoxInformation = new ListBox();
            buttonNyhetsskalla = new Button();
            tabPage2 = new TabPage();
            buttonVisning = new Button();
            textBox1 = new TextBox();
            buttonVisaSparadePoddar = new Button();
            buttonRadera = new Button();
            listBox3 = new ListBox();
            listBox2 = new ListBox();
            buttonVisa = new Button();
            listBox1 = new ListBox();
            errorProvider1 = new ErrorProvider(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(-1, 2);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1451, 939);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(radera_kategori);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(comboBoxKategori);
            tabPage1.Controls.Add(textBoxURL);
            tabPage1.Controls.Add(buttonSpara);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(listBoxLankar);
            tabPage1.Controls.Add(listBoxInformation);
            tabPage1.Controls.Add(buttonNyhetsskalla);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Margin = new Padding(4, 5, 4, 5);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 5, 4, 5);
            tabPage1.Size = new Size(1443, 901);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Hämta källa";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // radera_kategori
            // 
            radera_kategori.Location = new Point(523, 85);
            radera_kategori.Name = "radera_kategori";
            radera_kategori.Size = new Size(171, 34);
            radera_kategori.TabIndex = 19;
            radera_kategori.Text = "Radera Kategori";
            radera_kategori.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(976, 130);
            label2.Name = "label2";
            label2.Size = new Size(210, 25);
            label2.TabIndex = 18;
            label2.Text = "Skriv in namn till podden";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(523, 8);
            label3.Name = "label3";
            label3.Size = new Size(174, 25);
            label3.TabIndex = 17;
            label3.Text = "Välj/Skriv in Kategori";
            label3.Click += label3_Click;
            // 
            // comboBoxKategori
            // 
            comboBoxKategori.FormattingEnabled = true;
            comboBoxKategori.Location = new Point(523, 38);
            comboBoxKategori.Margin = new Padding(4, 5, 4, 5);
            comboBoxKategori.Name = "comboBoxKategori";
            comboBoxKategori.Size = new Size(171, 33);
            comboBoxKategori.TabIndex = 14;
            // 
            // textBoxURL
            // 
            textBoxURL.Location = new Point(4, 37);
            textBoxURL.Margin = new Padding(4, 5, 4, 5);
            textBoxURL.Name = "textBoxURL";
            textBoxURL.Size = new Size(508, 31);
            textBoxURL.TabIndex = 13;
            // 
            // buttonSpara
            // 
            buttonSpara.Location = new Point(976, 284);
            buttonSpara.Margin = new Padding(4, 5, 4, 5);
            buttonSpara.Name = "buttonSpara";
            buttonSpara.Size = new Size(107, 38);
            buttonSpara.TabIndex = 11;
            buttonSpara.Text = "Spara";
            buttonSpara.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 7);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 10;
            label1.Text = "Ange URL:";
            // 
            // listBoxLankar
            // 
            listBoxLankar.FormattingEnabled = true;
            listBoxLankar.Location = new Point(473, 167);
            listBoxLankar.Margin = new Padding(4, 5, 4, 5);
            listBoxLankar.Name = "listBoxLankar";
            listBoxLankar.Size = new Size(473, 504);
            listBoxLankar.TabIndex = 9;
            // 
            // listBoxInformation
            // 
            listBoxInformation.FormattingEnabled = true;
            listBoxInformation.Location = new Point(4, 167);
            listBoxInformation.Margin = new Padding(4, 5, 4, 5);
            listBoxInformation.Name = "listBoxInformation";
            listBoxInformation.Size = new Size(440, 504);
            listBoxInformation.TabIndex = 8;
            // 
            // buttonNyhetsskalla
            // 
            buttonNyhetsskalla.Location = new Point(4, 85);
            buttonNyhetsskalla.Margin = new Padding(4, 5, 4, 5);
            buttonNyhetsskalla.Name = "buttonNyhetsskalla";
            buttonNyhetsskalla.Size = new Size(286, 38);
            buttonNyhetsskalla.TabIndex = 7;
            buttonNyhetsskalla.Text = "Hämta och visa poddavsnitt";
            buttonNyhetsskalla.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(buttonVisning);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(buttonVisaSparadePoddar);
            tabPage2.Controls.Add(buttonRadera);
            tabPage2.Controls.Add(listBox3);
            tabPage2.Controls.Add(listBox2);
            tabPage2.Controls.Add(buttonVisa);
            tabPage2.Controls.Add(listBox1);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Margin = new Padding(4, 5, 4, 5);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 5, 4, 5);
            tabPage2.Size = new Size(1443, 901);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Visa Register";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonVisning
            // 
            buttonVisning.Location = new Point(393, 556);
            buttonVisning.Margin = new Padding(4, 5, 4, 5);
            buttonVisning.Name = "buttonVisning";
            buttonVisning.Size = new Size(203, 38);
            buttonVisning.TabIndex = 17;
            buttonVisning.Text = "Ange visningsnamn";
            buttonVisning.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(393, 501);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(365, 31);
            textBox1.TabIndex = 16;
            // 
            // buttonVisaSparadePoddar
            // 
            buttonVisaSparadePoddar.Location = new Point(243, 12);
            buttonVisaSparadePoddar.Margin = new Padding(4, 5, 4, 5);
            buttonVisaSparadePoddar.Name = "buttonVisaSparadePoddar";
            buttonVisaSparadePoddar.Size = new Size(239, 38);
            buttonVisaSparadePoddar.TabIndex = 11;
            buttonVisaSparadePoddar.Text = "Visa alla sparade poddar";
            buttonVisaSparadePoddar.UseVisualStyleBackColor = true;
            // 
            // buttonRadera
            // 
            buttonRadera.Location = new Point(127, 12);
            buttonRadera.Margin = new Padding(4, 5, 4, 5);
            buttonRadera.Name = "buttonRadera";
            buttonRadera.Size = new Size(107, 38);
            buttonRadera.TabIndex = 10;
            buttonRadera.Text = "Radera";
            buttonRadera.UseVisualStyleBackColor = true;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.Location = new Point(761, 95);
            listBox3.Margin = new Padding(4, 5, 4, 5);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(663, 354);
            listBox3.TabIndex = 9;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(393, 95);
            listBox2.Margin = new Padding(4, 5, 4, 5);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(349, 354);
            listBox2.TabIndex = 8;
            // 
            // buttonVisa
            // 
            buttonVisa.Location = new Point(11, 12);
            buttonVisa.Margin = new Padding(4, 5, 4, 5);
            buttonVisa.Name = "buttonVisa";
            buttonVisa.Size = new Size(107, 38);
            buttonVisa.TabIndex = 6;
            buttonVisa.Text = "Visa";
            buttonVisa.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(11, 95);
            listBox1.Margin = new Padding(4, 5, 4, 5);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(365, 354);
            listBox1.TabIndex = 5;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1452, 869);
            Controls.Add(tabControl1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox textBoxURL;
        private Button buttonSpara;
        private Label label1;
        private ListBox listBoxLankar;
        private ListBox listBoxInformation;
        private Button buttonNyhetsskalla;
        private TabPage tabPage2;
        private ListBox listBox3;
        private ListBox listBox2;
        private Button buttonVisa;
        private ListBox listBox1;
        private ErrorProvider errorProvider1;
        private Button buttonRadera;
        private Button buttonVisaSparadePoddar;
        private ComboBox comboBoxKategori;
        private ContextMenuStrip contextMenuStrip1;
        private Label label3;
        private Label label2;
        private Button radera_kategori;
        private Button buttonVisning;
        private TextBox textBox1;
    }
}
