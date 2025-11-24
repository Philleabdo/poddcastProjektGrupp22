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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            textBoxURL = new TextBox();
            buttonVisning = new Button();
            buttonSpara = new Button();
            label1 = new Label();
            listBoxLankar = new ListBox();
            listBoxInformation = new ListBox();
            buttonNyhetsskalla = new Button();
            listBox3 = new ListBox();
            listBox2 = new ListBox();
            button2 = new Button();
            button1 = new Button();
            listBox1 = new ListBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, -1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(798, 449);
            tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(textBoxURL);
            tabPage1.Controls.Add(buttonVisning);
            tabPage1.Controls.Add(buttonSpara);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(listBoxLankar);
            tabPage1.Controls.Add(listBoxInformation);
            tabPage1.Controls.Add(buttonNyhetsskalla);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(790, 421);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(listBox3);
            tabPage2.Controls.Add(listBox2);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(listBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(790, 421);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxURL
            // 
            textBoxURL.Location = new Point(4, 23);
            textBoxURL.Name = "textBoxURL";
            textBoxURL.Size = new Size(357, 23);
            textBoxURL.TabIndex = 13;
            // 
            // buttonVisning
            // 
            buttonVisning.Location = new Point(386, 23);
            buttonVisning.Name = "buttonVisning";
            buttonVisning.Size = new Size(142, 26);
            buttonVisning.TabIndex = 12;
            buttonVisning.Text = "Ange visningsnamn";
            buttonVisning.UseVisualStyleBackColor = true;
            // 
            // buttonSpara
            // 
            buttonSpara.Location = new Point(534, 23);
            buttonSpara.Name = "buttonSpara";
            buttonSpara.Size = new Size(75, 26);
            buttonSpara.TabIndex = 11;
            buttonSpara.Text = "Spara";
            buttonSpara.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 5);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 10;
            label1.Text = "Ange URL:";
            // 
            // listBoxLankar
            // 
            listBoxLankar.FormattingEnabled = true;
            listBoxLankar.Location = new Point(332, 101);
            listBoxLankar.Name = "listBoxLankar";
            listBoxLankar.Size = new Size(332, 304);
            listBoxLankar.TabIndex = 9;
            // 
            // listBoxInformation
            // 
            listBoxInformation.FormattingEnabled = true;
            listBoxInformation.Location = new Point(4, 101);
            listBoxInformation.Name = "listBoxInformation";
            listBoxInformation.Size = new Size(309, 304);
            listBoxInformation.TabIndex = 8;
            // 
            // buttonNyhetsskalla
            // 
            buttonNyhetsskalla.Location = new Point(4, 49);
            buttonNyhetsskalla.Name = "buttonNyhetsskalla";
            buttonNyhetsskalla.Size = new Size(200, 26);
            buttonNyhetsskalla.TabIndex = 7;
            buttonNyhetsskalla.Text = "Hämta och visa poddavsnitt";
            buttonNyhetsskalla.UseVisualStyleBackColor = true;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.Location = new Point(510, 70);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(202, 319);
            listBox3.TabIndex = 9;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(270, 70);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(234, 319);
            listBox2.TabIndex = 8;
            // 
            // button2
            // 
            button2.Location = new Point(686, 395);
            button2.Name = "button2";
            button2.Size = new Size(101, 23);
            button2.TabIndex = 7;
            button2.Text = "Töm hela listan";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(7, 4);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Visa";
            button1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(7, 70);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(257, 319);
            listBox1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBoxURL;
        private Button buttonVisning;
        private Button buttonSpara;
        private Label label1;
        private ListBox listBoxLankar;
        private ListBox listBoxInformation;
        private Button buttonNyhetsskalla;
        private ListBox listBox3;
        private ListBox listBox2;
        private Button button2;
        private Button button1;
        private ListBox listBox1;
    }
}
