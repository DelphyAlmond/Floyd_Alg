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
            scenePanel.Location = new Point(12, 22);
            scenePanel.Name = "scenePanel";
            scenePanel.Size = new Size(1050, 1164);
            scenePanel.TabIndex = 0;
            // 
            // scrollBarA
            // 
            scrollBarA.LargeChange = 1;
            scrollBarA.Location = new Point(12, 1205);
            scrollBarA.Maximum = vertices.Count - 1; // * vertices.Count; // - [*]
            scrollBarA.Name = "scrollBarA";
            scrollBarA.Size = new Size(1050, 45);
            scrollBarA.TabIndex = 1;
            scrollBarA.Value = 1;
            scrollBarA.ValueChanged += OnScrollBarValueChanged;
            // 
            // GraphicImplementationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DeepPink;
            ClientSize = new Size(1074, 1269);
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