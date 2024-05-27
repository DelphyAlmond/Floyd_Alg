namespace FloydAlg
{
    partial class GraphicImplementationForm
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
            scenePanel = new Panel();
            scrollBarA = new HScrollBar();

            SuspendLayout();
            // 
            // scenePanel
            // 
            scenePanel.BackColor = Color.MintCream;
            scenePanel.Location = new Point(12, 12);
            scenePanel.Name = "scenePanel";
            scenePanel.Size = new Size(1050, 1045);
            scenePanel.TabIndex = 0;
            // 
            // scrollBar
            // 
            scrollBarA.Location = new Point(12, 1078);
            scrollBarA.Name = "scrollBar";
            scrollBarA.Size = new Size(1050, 45);
            scrollBarA.TabIndex = 1;
            scrollBarA.Maximum = vertices.Count * vertices.Count;
            scrollBarA.ValueChanged += new EventHandler(OnScrollBarValueChanged);
            // 
            // GraphicImplementationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DeepPink;
            ClientSize = new Size(1074, 1144);
            Controls.Add(scrollBarA);
            Controls.Add(scenePanel);
            Name = "GraphicImplementationForm";
            Text = "GraphicImplementationForm";
            ResumeLayout(false);
        }

        #endregion

        private Panel scenePanel;
        private HScrollBar scrollBarA;
    }
}