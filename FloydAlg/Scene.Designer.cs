namespace FloydAlg
{
    partial class Scene
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
            btnAddVertex = new Button();
            txtVertexName = new TextBox();
            startV = new TextBox();
            destinationV = new TextBox();
            numConnectionWeight = new NumericUpDown();
            noUseLabel = new Label();
            Connector = new GroupBox();
            graphPanel = new Panel();
            btnClear = new Button();
            btnRemoveVertex = new Button();
            prevState = new Button();
            nextState = new Button();
            label1 = new Label();
            stateBox = new ListBox();
            btnRunAlgorithm = new Button();
            Matrixpanel = new Panel();
            InfButton = new Button();
            ((System.ComponentModel.ISupportInitialize)numConnectionWeight).BeginInit();
            Connector.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddVertex
            // 
            btnAddVertex.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddVertex.Location = new Point(899, 798);
            btnAddVertex.Name = "btnAddVertex";
            btnAddVertex.Size = new Size(153, 46);
            btnAddVertex.TabIndex = 0;
            btnAddVertex.Text = "Add";
            btnAddVertex.UseVisualStyleBackColor = true;
            btnAddVertex.Click += btnAddVertex_Click;
            // 
            // txtVertexName
            // 
            txtVertexName.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtVertexName.Location = new Point(1071, 802);
            txtVertexName.Name = "txtVertexName";
            txtVertexName.Size = new Size(122, 39);
            txtVertexName.TabIndex = 1;
            // 
            // startV
            // 
            startV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            startV.Location = new Point(34, 87);
            startV.Name = "startV";
            startV.Size = new Size(130, 39);
            startV.TabIndex = 2;
            startV.TextChanged += txtStartVertex_TextChanged;
            // 
            // destinationV
            // 
            destinationV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            destinationV.Location = new Point(312, 87);
            destinationV.Name = "destinationV";
            destinationV.Size = new Size(116, 39);
            destinationV.TabIndex = 3;
            destinationV.TextChanged += txtDestinationVertex_TextChanged;
            // 
            // numConnectionWeight
            // 
            numConnectionWeight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numConnectionWeight.Location = new Point(184, 88);
            numConnectionWeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numConnectionWeight.Name = "numConnectionWeight";
            numConnectionWeight.Size = new Size(110, 39);
            numConnectionWeight.TabIndex = 4;
            numConnectionWeight.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // noUseLabel
            // 
            noUseLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            noUseLabel.AutoSize = true;
            noUseLabel.ForeColor = SystemColors.ControlLightLight;
            noUseLabel.Location = new Point(31, 33);
            noUseLabel.Name = "noUseLabel";
            noUseLabel.Size = new Size(394, 32);
            noUseLabel.TabIndex = 5;
            noUseLabel.Text = "From  -  weight of connection  -  to";
            // 
            // Connector
            // 
            Connector.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Connector.Controls.Add(numConnectionWeight);
            Connector.Controls.Add(noUseLabel);
            Connector.Controls.Add(startV);
            Connector.Controls.Add(destinationV);
            Connector.ForeColor = SystemColors.ButtonHighlight;
            Connector.Location = new Point(899, 852);
            Connector.Name = "Connector";
            Connector.Size = new Size(461, 142);
            Connector.TabIndex = 6;
            Connector.TabStop = false;
            Connector.Text = "Connector";
            // 
            // graphPanel
            // 
            graphPanel.Location = new Point(14, 12);
            graphPanel.Name = "graphPanel";
            graphPanel.Size = new Size(867, 982);
            graphPanel.TabIndex = 7;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(899, 12);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(461, 46);
            btnClear.TabIndex = 8;
            btnClear.Text = "Start new graph (remove all)";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnRemoveVertex
            // 
            btnRemoveVertex.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRemoveVertex.Location = new Point(1211, 798);
            btnRemoveVertex.Name = "btnRemoveVertex";
            btnRemoveVertex.Size = new Size(149, 46);
            btnRemoveVertex.TabIndex = 9;
            btnRemoveVertex.Text = "Delete";
            btnRemoveVertex.UseVisualStyleBackColor = true;
            btnRemoveVertex.Click += btnRemoveVertex_Click;
            // 
            // prevState
            // 
            prevState.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            prevState.Location = new Point(899, 738);
            prevState.Name = "prevState";
            prevState.Size = new Size(230, 46);
            prevState.TabIndex = 10;
            prevState.Text = "Previous step";
            prevState.UseVisualStyleBackColor = true;
            prevState.Click += prevState_Click;
            // 
            // nextState
            // 
            nextState.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            nextState.Location = new Point(1143, 738);
            nextState.Name = "nextState";
            nextState.Size = new Size(217, 46);
            nextState.TabIndex = 11;
            nextState.Text = "Next step";
            nextState.UseVisualStyleBackColor = true;
            nextState.Click += nextState_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(1029, 491);
            label1.Name = "label1";
            label1.Size = new Size(195, 32);
            label1.TabIndex = 6;
            label1.Text = "< State History >";
            // 
            // stateBox
            // 
            stateBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            stateBox.BackColor = Color.DarkCyan;
            stateBox.ForeColor = SystemColors.Window;
            stateBox.FormattingEnabled = true;
            stateBox.Location = new Point(899, 526);
            stateBox.Name = "stateBox";
            stateBox.Size = new Size(461, 196);
            stateBox.TabIndex = 12;
            // 
            // btnRunAlgorithm
            // 
            btnRunAlgorithm.Anchor = AnchorStyles.Right;
            btnRunAlgorithm.Location = new Point(899, 425);
            btnRunAlgorithm.Name = "btnRunAlgorithm";
            btnRunAlgorithm.Size = new Size(465, 42);
            btnRunAlgorithm.TabIndex = 13;
            btnRunAlgorithm.Text = "Implement Floyd W. algorithm";
            btnRunAlgorithm.UseVisualStyleBackColor = true;
            btnRunAlgorithm.Click += btnRunAlgorithm_Click;
            // 
            // Matrixpanel
            // 
            Matrixpanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            Matrixpanel.Location = new Point(899, 74);
            Matrixpanel.Name = "Matrixpanel";
            Matrixpanel.Size = new Size(354, 335);
            Matrixpanel.TabIndex = 14;
            // 
            // InfButton
            // 
            InfButton.ForeColor = SystemColors.ActiveCaptionText;
            InfButton.Location = new Point(1270, 243);
            InfButton.Name = "InfButton";
            InfButton.Size = new Size(90, 166);
            InfButton.TabIndex = 15;
            InfButton.Text = "INFO";
            InfButton.UseVisualStyleBackColor = true;
            InfButton.Click += InfButton_Click;
            // 
            // Scene
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(1372, 1015);
            Controls.Add(InfButton);
            Controls.Add(Matrixpanel);
            Controls.Add(btnRunAlgorithm);
            Controls.Add(stateBox);
            Controls.Add(label1);
            Controls.Add(nextState);
            Controls.Add(prevState);
            Controls.Add(btnRemoveVertex);
            Controls.Add(btnClear);
            Controls.Add(graphPanel);
            Controls.Add(Connector);
            Controls.Add(txtVertexName);
            Controls.Add(btnAddVertex);
            Name = "Scene";
            Text = "Scene";
            ((System.ComponentModel.ISupportInitialize)numConnectionWeight).EndInit();
            Connector.ResumeLayout(false);
            Connector.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void DestinationV_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button btnAddVertex;
        private TextBox txtVertexName;
        private TextBox startV;
        private TextBox destinationV;
        private NumericUpDown numConnectionWeight;
        private Label noUseLabel;
        private GroupBox Connector;
        private Panel graphPanel;
        private Button btnClear;
        private Button btnRemoveVertex;
        private Button prevState;
        private Button nextState;
        private Label label1;
        private ListBox stateBox;
        private Button btnRunAlgorithm;
        private Panel Matrixpanel;
        private Button InfButton;
    }
}