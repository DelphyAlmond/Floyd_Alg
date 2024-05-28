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
            NotusedLabel = new Label();
            stateBox = new ListBox();
            btnRunAlgorithm = new Button();
            Matrixpanel = new Panel();
            InfButton = new Button();
            btnShortestBetween = new Button();
            label2 = new Label();
            labelUnabled = new Label();
            VertexFromBox = new TextBox();
            VertexToBox = new TextBox();
            ShortestEdgeLabel = new Label();
            btnNextMtxStep = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numConnectionWeight).BeginInit();
            Connector.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddVertex
            // 
            btnAddVertex.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddVertex.Location = new Point(476, 1148);
            btnAddVertex.Name = "btnAddVertex";
            btnAddVertex.Size = new Size(134, 47);
            btnAddVertex.TabIndex = 0;
            btnAddVertex.Text = "Add";
            btnAddVertex.UseVisualStyleBackColor = true;
            btnAddVertex.Click += btnAddVertex_Click;
            // 
            // txtVertexName
            // 
            txtVertexName.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtVertexName.Location = new Point(616, 1151);
            txtVertexName.Name = "txtVertexName";
            txtVertexName.Size = new Size(129, 39);
            txtVertexName.TabIndex = 1;
            // 
            // startV
            // 
            startV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            startV.Location = new Point(31, 72);
            startV.Name = "startV";
            startV.Size = new Size(130, 39);
            startV.TabIndex = 2;
            startV.TextChanged += txtStartVertex_TextChanged;
            // 
            // destinationV
            // 
            destinationV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            destinationV.Location = new Point(309, 72);
            destinationV.Name = "destinationV";
            destinationV.Size = new Size(116, 39);
            destinationV.TabIndex = 3;
            destinationV.TextChanged += txtDestinationVertex_TextChanged;
            // 
            // numConnectionWeight
            // 
            numConnectionWeight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numConnectionWeight.Location = new Point(181, 73);
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
            noUseLabel.Location = new Point(28, 28);
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
            Connector.Controls.Add(destinationV);
            Connector.Controls.Add(startV);
            Connector.ForeColor = SystemColors.ButtonHighlight;
            Connector.Location = new Point(11, 1078);
            Connector.Name = "Connector";
            Connector.Size = new Size(459, 119);
            Connector.TabIndex = 6;
            Connector.TabStop = false;
            Connector.Text = "Connector";
            // 
            // graphPanel
            // 
            graphPanel.Location = new Point(14, 12);
            graphPanel.Name = "graphPanel";
            graphPanel.Size = new Size(947, 1060);
            graphPanel.TabIndex = 7;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(983, 12);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(571, 69);
            btnClear.TabIndex = 8;
            btnClear.Text = "Start new graph (remove all)";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnRemoveVertex
            // 
            btnRemoveVertex.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRemoveVertex.Location = new Point(751, 1148);
            btnRemoveVertex.Name = "btnRemoveVertex";
            btnRemoveVertex.Size = new Size(210, 46);
            btnRemoveVertex.TabIndex = 9;
            btnRemoveVertex.Text = "Delete";
            btnRemoveVertex.UseVisualStyleBackColor = true;
            btnRemoveVertex.Click += btnRemoveVertex_Click;
            // 
            // prevState
            // 
            prevState.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            prevState.Location = new Point(985, 1026);
            prevState.Name = "prevState";
            prevState.Size = new Size(284, 46);
            prevState.TabIndex = 10;
            prevState.Text = "Previous step";
            prevState.UseVisualStyleBackColor = true;
            prevState.Click += prevState_Click;
            // 
            // nextState
            // 
            nextState.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            nextState.Location = new Point(1275, 1025);
            nextState.Name = "nextState";
            nextState.Size = new Size(282, 46);
            nextState.TabIndex = 11;
            nextState.Text = "Next step";
            nextState.UseVisualStyleBackColor = true;
            nextState.Click += nextState_Click;
            // 
            // NotusedLabel
            // 
            NotusedLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            NotusedLabel.AutoSize = true;
            NotusedLabel.ForeColor = SystemColors.ButtonHighlight;
            NotusedLabel.Location = new Point(1179, 756);
            NotusedLabel.Name = "NotusedLabel";
            NotusedLabel.Size = new Size(195, 32);
            NotusedLabel.TabIndex = 6;
            NotusedLabel.Text = "< State History >";
            // 
            // stateBox
            // 
            stateBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            stateBox.BackColor = Color.DarkCyan;
            stateBox.ForeColor = SystemColors.Window;
            stateBox.FormattingEnabled = true;
            stateBox.Location = new Point(986, 791);
            stateBox.Name = "stateBox";
            stateBox.Size = new Size(571, 228);
            stateBox.TabIndex = 12;
            // stateBox.SelectedIndexChanged += stateBox_SelectedIndexChanged;

            // 
            // btnRunAlgorithm
            // 
            btnRunAlgorithm.Anchor = AnchorStyles.Right;
            btnRunAlgorithm.Location = new Point(476, 1095);
            btnRunAlgorithm.Name = "btnRunAlgorithm";
            btnRunAlgorithm.Size = new Size(485, 42);
            btnRunAlgorithm.TabIndex = 13;
            btnRunAlgorithm.Text = "Implement algorithm";
            btnRunAlgorithm.UseVisualStyleBackColor = true;
            btnRunAlgorithm.Click += btnRunAlgorithm_Click;
            // 
            // Matrixpanel
            // 
            Matrixpanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            Matrixpanel.Location = new Point(983, 87);
            Matrixpanel.Name = "Matrixpanel";
            Matrixpanel.Size = new Size(571, 584);
            Matrixpanel.TabIndex = 14;
            // 
            // InfButton
            // 
            InfButton.ForeColor = SystemColors.ActiveCaptionText;
            InfButton.Location = new Point(983, 677);
            InfButton.Name = "InfButton";
            InfButton.Size = new Size(107, 75);
            InfButton.TabIndex = 15;
            InfButton.Text = "INFO";
            InfButton.UseVisualStyleBackColor = true;
            InfButton.Click += InfButton_Click;
            // 
            // btnShortestBetween
            // 
            btnShortestBetween.ForeColor = SystemColors.ActiveCaptionText;
            btnShortestBetween.Location = new Point(986, 1095);
            btnShortestBetween.Name = "btnShortestBetween";
            btnShortestBetween.Size = new Size(570, 42);
            btnShortestBetween.TabIndex = 17;
            btnShortestBetween.Text = "Show shortest path";
            btnShortestBetween.UseVisualStyleBackColor = true;
            btnShortestBetween.Click += btnShortestBetween_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(929, 476);
            label2.Name = "label2";
            label2.Size = new Size(0, 32);
            label2.TabIndex = 18;
            // 
            // labelUnabled
            // 
            labelUnabled.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            labelUnabled.AutoSize = true;
            labelUnabled.ForeColor = SystemColors.ButtonHighlight;
            labelUnabled.Location = new Point(977, 1156);
            labelUnabled.Name = "labelUnabled";
            labelUnabled.Size = new Size(482, 32);
            labelUnabled.TabIndex = 19;
            labelUnabled.Text = "The shortest path between         and         is";
            // 
            // VertexFromBox
            // 
            VertexFromBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            VertexFromBox.Location = new Point(1280, 1156);
            VertexFromBox.Name = "VertexFromBox";
            VertexFromBox.Size = new Size(45, 39);
            VertexFromBox.TabIndex = 20;
            // 
            // VertexToBox
            // 
            VertexToBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            VertexToBox.Location = new Point(1382, 1156);
            VertexToBox.Name = "VertexToBox";
            VertexToBox.Size = new Size(45, 39);
            VertexToBox.TabIndex = 21;
            // 
            // ShortestEdgeLabel
            // 
            ShortestEdgeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            ShortestEdgeLabel.AutoSize = true;
            ShortestEdgeLabel.ForeColor = SystemColors.ButtonHighlight;
            ShortestEdgeLabel.Location = new Point(1471, 1156);
            ShortestEdgeLabel.Name = "ShortestEdgeLabel";
            ShortestEdgeLabel.Size = new Size(29, 32);
            ShortestEdgeLabel.TabIndex = 22;
            ShortestEdgeLabel.Text = "...";
            // 
            // btnNextMtxStep
            // 
            btnNextMtxStep.ForeColor = SystemColors.ActiveCaptionText;
            btnNextMtxStep.Location = new Point(1097, 677);
            btnNextMtxStep.Name = "btnNextMtxStep";
            btnNextMtxStep.Size = new Size(228, 75);
            btnNextMtxStep.TabIndex = 23;
            btnNextMtxStep.Text = "Steps of  matrix calculations";
            btnNextMtxStep.UseVisualStyleBackColor = true;
            btnNextMtxStep.Click += btnNextMtxStep_Click;
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(1331, 678);
            button1.Name = "button1";
            button1.Size = new Size(226, 74);
            button1.TabIndex = 24;
            button1.Text = "Previous session";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnPrevSLoadFromFile;
            // 
            // Scene
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(1566, 1212);
            Controls.Add(button1);
            Controls.Add(btnNextMtxStep);
            Controls.Add(ShortestEdgeLabel);
            Controls.Add(VertexToBox);
            Controls.Add(VertexFromBox);
            Controls.Add(labelUnabled);
            Controls.Add(label2);
            Controls.Add(btnShortestBetween);
            Controls.Add(InfButton);
            Controls.Add(Matrixpanel);
            Controls.Add(btnRunAlgorithm);
            Controls.Add(stateBox);
            Controls.Add(NotusedLabel);
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
        private Label NotusedLabel;
        private ListBox stateBox;
        private Button btnRunAlgorithm;
        private Panel Matrixpanel;
        private Button InfButton;
        // private Button matrixCalculations;
        private Button btnShortestBetween;
        private Label label2;
        private Label labelUnabled;
        private TextBox VertexFromBox;
        private TextBox VertexToBox;
        private Label ShortestEdgeLabel;
        private Button btnNextMtxStep;
        private Button button1;
    }
}