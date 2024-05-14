namespace FloydAlg
{
    partial class InformationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformationForm));
            InfTextBox = new RichTextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // InfTextBox
            // 
            InfTextBox.Location = new Point(25, 98);
            InfTextBox.Name = "InfTextBox";
            InfTextBox.Size = new Size(932, 622);
            InfTextBox.TabIndex = 0;
            InfTextBox.Text = resources.GetString("InfTextBox.Text");
            // 
            // label1
            // 
            label1.BackColor = Color.Teal;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(224, 20);
            label1.Name = "label1";
            label1.Size = new Size(538, 64);
            label1.TabIndex = 1;
            label1.Text = "Floyd Algorithm (Vizualization)";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.ImageLocation = "C:\\Users\\inna\\source\\foxfordFloydFormula.jpeg";
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(124, 749);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(725, 111);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // InformationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSeaGreen;
            ClientSize = new Size(985, 890);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(InfTextBox);
            Name = "InformationForm";
            Text = "InformationForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox InfTextBox;
        private Label label1;
        private PictureBox pictureBox1;
    }
}