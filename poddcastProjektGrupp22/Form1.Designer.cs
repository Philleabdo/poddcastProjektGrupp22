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
            buttonAndraKategoriNamn = new Button();
            textBoxKategoriNamn = new TextBox();
            comboBoxFilterKategori = new ComboBox();
            label4 = new Label();
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
            tabControl1.Location = new Point(-1, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1016, 563);
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
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1008, 535);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Hämta källa";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // radera_kategori
            // 
            radera_kategori.Location = new Point(366, 51);
            radera_kategori.Margin = new Padding(2);
            radera_kategori.Name = "radera_kategori";
            radera_kategori.Size = new Size(120, 20);
            radera_kategori.TabIndex = 19;
            radera_kategori.Text = "Radera Kategori";
            radera_kategori.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(683, 78);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(139, 15);
            label2.TabIndex = 18;
            label2.Text = "Skriv in namn till podden";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(366, 5);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(115, 15);
            label3.TabIndex = 17;
            label3.Text = "Välj/Skriv in Kategori";
            label3.Click += label3_Click;
            // 
            // comboBoxKategori
            // 
            comboBoxKategori.FormattingEnabled = true;
            comboBoxKategori.Location = new Point(366, 23);
            comboBoxKategori.Name = "comboBoxKategori";
            comboBoxKategori.Size = new Size(121, 23);
            comboBoxKategori.TabIndex = 14;
            // 
            // textBoxURL
            // 
            textBoxURL.Location = new Point(3, 22);
            textBoxURL.Name = "textBoxURL";
            textBoxURL.Size = new Size(357, 23);
            textBoxURL.TabIndex = 13;
            // 
            // buttonSpara
            // 
            buttonSpara.Location = new Point(683, 170);
            buttonSpara.Name = "buttonSpara";
            buttonSpara.Size = new Size(75, 23);
            buttonSpara.TabIndex = 11;
            buttonSpara.Text = "Spara";
            buttonSpara.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 4);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 10;
            label1.Text = "Ange URL:";
            // 
            // listBoxLankar
            // 
            listBoxLankar.FormattingEnabled = true;
            listBoxLankar.Location = new Point(331, 100);
            listBoxLankar.Name = "listBoxLankar";
            listBoxLankar.Size = new Size(332, 304);
            listBoxLankar.TabIndex = 9;
            // 
            // listBoxInformation
            // 
            listBoxInformation.FormattingEnabled = true;
            listBoxInformation.Location = new Point(3, 100);
            listBoxInformation.Name = "listBoxInformation";
            listBoxInformation.Size = new Size(309, 304);
            listBoxInformation.TabIndex = 8;
            // 
            // buttonNyhetsskalla
            // 
            buttonNyhetsskalla.Location = new Point(3, 51);
            buttonNyhetsskalla.Name = "buttonNyhetsskalla";
            buttonNyhetsskalla.Size = new Size(200, 23);
            buttonNyhetsskalla.TabIndex = 7;
            buttonNyhetsskalla.Text = "Hämta och visa poddavsnitt";
            buttonNyhetsskalla.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(buttonAndraKategoriNamn);
            tabPage2.Controls.Add(textBoxKategoriNamn);
            tabPage2.Controls.Add(comboBoxFilterKategori);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(buttonVisning);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(buttonVisaSparadePoddar);
            tabPage2.Controls.Add(buttonRadera);
            tabPage2.Controls.Add(listBox3);
            tabPage2.Controls.Add(listBox2);
            tabPage2.Controls.Add(buttonVisa);
            tabPage2.Controls.Add(listBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1008, 535);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Visa Register";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonAndraKategoriNamn
            // 
            buttonAndraKategoriNamn.Location = new Point(533, 313);
            buttonAndraKategoriNamn.Name = "buttonAndraKategoriNamn";
            buttonAndraKategoriNamn.Size = new Size(147, 23);
            buttonAndraKategoriNamn.TabIndex = 22;
            buttonAndraKategoriNamn.Text = "Ändra kategorinamn";
            buttonAndraKategoriNamn.UseVisualStyleBackColor = true;
            // 
            // textBoxKategoriNamn
            // 
            textBoxKategoriNamn.Location = new Point(533, 284);
            textBoxKategoriNamn.Name = "textBoxKategoriNamn";
            textBoxKategoriNamn.Size = new Size(159, 23);
            textBoxKategoriNamn.TabIndex = 21;
            // 
            // comboBoxFilterKategori
            // 
            comboBoxFilterKategori.FormattingEnabled = true;
            comboBoxFilterKategori.Location = new Point(118, 284);
            comboBoxFilterKategori.Name = "comboBoxFilterKategori";
            comboBoxFilterKategori.Size = new Size(121, 23);
            comboBoxFilterKategori.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 284);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 19;
            label4.Text = "Sortera kategorier:";
            // 
            // buttonVisning
            // 
            buttonVisning.Location = new Point(275, 312);
            buttonVisning.Name = "buttonVisning";
            buttonVisning.Size = new Size(142, 23);
            buttonVisning.TabIndex = 17;
            buttonVisning.Text = "Ange visningsnamn";
            buttonVisning.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(275, 284);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(194, 23);
            textBox1.TabIndex = 16;
            // 
            // buttonVisaSparadePoddar
            // 
            buttonVisaSparadePoddar.Location = new Point(170, 7);
            buttonVisaSparadePoddar.Name = "buttonVisaSparadePoddar";
            buttonVisaSparadePoddar.Size = new Size(167, 23);
            buttonVisaSparadePoddar.TabIndex = 11;
            buttonVisaSparadePoddar.Text = "Visa alla sparade poddar";
            buttonVisaSparadePoddar.UseVisualStyleBackColor = true;
            // 
            // buttonRadera
            // 
            buttonRadera.Location = new Point(89, 7);
            buttonRadera.Name = "buttonRadera";
            buttonRadera.Size = new Size(75, 23);
            buttonRadera.TabIndex = 10;
            buttonRadera.Text = "Radera";
            buttonRadera.UseVisualStyleBackColor = true;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.Location = new Point(533, 57);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(465, 214);
            listBox3.TabIndex = 9;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(275, 57);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(246, 214);
            listBox2.TabIndex = 8;
            // 
            // buttonVisa
            // 
            buttonVisa.Location = new Point(8, 7);
            buttonVisa.Name = "buttonVisa";
            buttonVisa.Size = new Size(75, 23);
            buttonVisa.TabIndex = 6;
            buttonVisa.Text = "Visa";
            buttonVisa.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(8, 57);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(257, 214);
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 521);
            Controls.Add(tabControl1);
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
        private Label label4;
        private ComboBox comboBoxFilterKategori;
        private Button buttonAndraKategoriNamn;
        private TextBox textBoxKategoriNamn;
    }
}
