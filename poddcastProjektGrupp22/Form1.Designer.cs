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
            this.buttonNyhetsskalla = new Button();
            this.listBoxInformation = new ListBox();
            this.listBoxLankar = new ListBox();
            label1 = new Label();
            this.buttonSpara = new Button();
            buttonVisning = new Button();
            textBoxURL = new TextBox();
            SuspendLayout();
            // 
            // buttonNyhetskalla
            // 
            this.buttonNyhetsskalla.Location = new Point(12, 56);
            this.buttonNyhetsskalla.Name = "buttonNyhetskalla";
            this.buttonNyhetsskalla.Size = new Size(200, 23);
            this.buttonNyhetsskalla.TabIndex = 0;
            this.buttonNyhetsskalla.Text = "Hämta och visa nyhetskälla";
            this.buttonNyhetsskalla.UseVisualStyleBackColor = true;
            // 
            // listBoxInformation
            // 
            this.listBoxInformation.FormattingEnabled = true;
            this.listBoxInformation.Location = new Point(12, 105);
            this.listBoxInformation.Name = "listBoxInformation";
            this.listBoxInformation.Size = new Size(309, 304);
            this.listBoxInformation.TabIndex = 1;
            // 
            // listBoxLankar
            // 
            this.listBoxLankar.FormattingEnabled = true;
            this.listBoxLankar.Location = new Point(340, 105);
            this.listBoxLankar.Name = "listBoxLankar";
            this.listBoxLankar.Size = new Size(332, 304);
            this.listBoxLankar.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 3;
            label1.Text = "Ange URL:";
            // 
            // buttonSpara
            // 
            this.buttonSpara.Location = new Point(12, 415);
            this.buttonSpara.Name = "buttonSpara";
            this.buttonSpara.Size = new Size(75, 23);
            this.buttonSpara.TabIndex = 4;
            this.buttonSpara.Text = "Spara";
            this.buttonSpara.UseVisualStyleBackColor = true;
            // 
            // buttonVisning
            // 
            buttonVisning.Location = new Point(93, 415);
            buttonVisning.Name = "buttonVisning";
            buttonVisning.Size = new Size(142, 23);
            buttonVisning.TabIndex = 5;
            buttonVisning.Text = "Ange visningsnamn";
            buttonVisning.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBoxURL.Location = new Point(12, 27);
            textBoxURL.Name = "textBox1";
            textBoxURL.Size = new Size(357, 23);
            textBoxURL.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxURL);
            Controls.Add(buttonVisning);
            Controls.Add(this.buttonSpara);
            Controls.Add(label1);
            Controls.Add(this.listBoxLankar);
            Controls.Add(this.listBoxInformation);
            Controls.Add(this.buttonNyhetsskalla);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonNyhetsskalla;
        private ListBox listBoxLankar;
        private ListBox listBoxInformation;
        private Label label1;
        private Button buttonSpara;
        private Button buttonVisning;
        private TextBox textBoxURL;
    }
}
