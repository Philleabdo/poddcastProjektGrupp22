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
            buttonNyhetsskalla = new Button();
            listBoxInformation = new ListBox();
            listBoxLankar = new ListBox();
            label1 = new Label();
            buttonSpara = new Button();
            buttonVisning = new Button();
            textBoxURL = new TextBox();
            SuspendLayout();
            // 
            // buttonNyhetsskalla
            // 
            buttonNyhetsskalla.Location = new Point(12, 56);
            buttonNyhetsskalla.Name = "buttonNyhetsskalla";
            buttonNyhetsskalla.Size = new Size(200, 23);
            buttonNyhetsskalla.TabIndex = 0;
            buttonNyhetsskalla.Text = "Hämta och visa poddavsnitt";
            buttonNyhetsskalla.UseVisualStyleBackColor = true;
            // 
            // listBoxInformation
            // 
            listBoxInformation.FormattingEnabled = true;
            listBoxInformation.Location = new Point(12, 105);
            listBoxInformation.Name = "listBoxInformation";
            listBoxInformation.Size = new Size(309, 304);
            listBoxInformation.TabIndex = 1;
            // 
            // listBoxLankar
            // 
            listBoxLankar.FormattingEnabled = true;
            listBoxLankar.Location = new Point(340, 105);
            listBoxLankar.Name = "listBoxLankar";
            listBoxLankar.Size = new Size(332, 304);
            listBoxLankar.TabIndex = 2;
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
            buttonSpara.Location = new Point(12, 415);
            buttonSpara.Name = "buttonSpara";
            buttonSpara.Size = new Size(75, 23);
            buttonSpara.TabIndex = 4;
            buttonSpara.Text = "Spara";
            buttonSpara.UseVisualStyleBackColor = true;
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
            // textBoxURL
            // 
            textBoxURL.Location = new Point(12, 27);
            textBoxURL.Name = "textBoxURL";
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
            Controls.Add(buttonSpara);
            Controls.Add(label1);
            Controls.Add(listBoxLankar);
            Controls.Add(listBoxInformation);
            Controls.Add(buttonNyhetsskalla);
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
