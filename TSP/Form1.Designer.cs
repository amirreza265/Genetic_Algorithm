namespace TSP
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
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            panel1 = new Panel();
            dgvPoints = new DataGridView();
            btnStart = new Button();
            txtPopulation = new NumericUpDown();
            label2 = new Label();
            txtGenerationNumber = new NumericUpDown();
            label1 = new Label();
            pnlAddPoint = new Panel();
            splitContainer3 = new SplitContainer();
            txtNewpointX = new NumericUpDown();
            txtNewpointY = new NumericUpDown();
            btnAddNewPoint = new Button();
            fplotPoints = new ScottPlot.FormsPlot();
            fplotGneration = new ScottPlot.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPoints).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPopulation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGenerationNumber).BeginInit();
            pnlAddPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtNewpointX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNewpointY).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.ButtonFace;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(fplotGneration);
            splitContainer1.Size = new Size(1021, 630);
            splitContainer1.SplitterDistance = 361;
            splitContainer1.SplitterWidth = 10;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.BackColor = SystemColors.ButtonFace;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.BackColor = SystemColors.ButtonHighlight;
            splitContainer2.Panel1.Controls.Add(panel1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(fplotPoints);
            splitContainer2.Size = new Size(1021, 361);
            splitContainer2.SplitterDistance = 423;
            splitContainer2.SplitterWidth = 10;
            splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(dgvPoints);
            panel1.Controls.Add(btnStart);
            panel1.Controls.Add(txtPopulation);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtGenerationNumber);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pnlAddPoint);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(423, 361);
            panel1.TabIndex = 0;
            // 
            // dgvPoints
            // 
            dgvPoints.AllowUserToAddRows = false;
            dgvPoints.AllowUserToDeleteRows = false;
            dgvPoints.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPoints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPoints.Dock = DockStyle.Fill;
            dgvPoints.GridColor = SystemColors.ActiveCaptionText;
            dgvPoints.Location = new Point(0, 127);
            dgvPoints.Name = "dgvPoints";
            dgvPoints.ReadOnly = true;
            dgvPoints.RowHeadersWidth = 51;
            dgvPoints.RowTemplate.Height = 29;
            dgvPoints.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPoints.ShowEditingIcon = false;
            dgvPoints.Size = new Size(421, 203);
            dgvPoints.TabIndex = 6;
            // 
            // btnStart
            // 
            btnStart.Dock = DockStyle.Bottom;
            btnStart.Location = new Point(0, 330);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(421, 29);
            btnStart.TabIndex = 5;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtPopulation
            // 
            txtPopulation.Dock = DockStyle.Top;
            txtPopulation.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            txtPopulation.Location = new Point(0, 100);
            txtPopulation.Maximum = new decimal(new int[] { 1661992950, 1808227885, 5, 0 });
            txtPopulation.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            txtPopulation.Name = "txtPopulation";
            txtPopulation.Size = new Size(421, 27);
            txtPopulation.TabIndex = 4;
            txtPopulation.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(0, 80);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 3;
            label2.Text = "Population  :";
            // 
            // txtGenerationNumber
            // 
            txtGenerationNumber.Dock = DockStyle.Top;
            txtGenerationNumber.Location = new Point(0, 53);
            txtGenerationNumber.Maximum = new decimal(new int[] { 1661992950, 1808227885, 5, 0 });
            txtGenerationNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtGenerationNumber.Name = "txtGenerationNumber";
            txtGenerationNumber.Size = new Size(421, 27);
            txtGenerationNumber.TabIndex = 2;
            txtGenerationNumber.Value = new decimal(new int[] { 4000, 0, 0, 0 });
            txtGenerationNumber.ValueChanged += txtGenerationNumber_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 33);
            label1.Name = "label1";
            label1.Size = new Size(147, 20);
            label1.TabIndex = 1;
            label1.Text = "Generation Number :";
            // 
            // pnlAddPoint
            // 
            pnlAddPoint.BorderStyle = BorderStyle.Fixed3D;
            pnlAddPoint.Controls.Add(splitContainer3);
            pnlAddPoint.Controls.Add(btnAddNewPoint);
            pnlAddPoint.Dock = DockStyle.Top;
            pnlAddPoint.Location = new Point(0, 0);
            pnlAddPoint.Name = "pnlAddPoint";
            pnlAddPoint.Size = new Size(421, 33);
            pnlAddPoint.TabIndex = 0;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(94, 0);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(txtNewpointX);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(txtNewpointY);
            splitContainer3.Size = new Size(323, 29);
            splitContainer3.SplitterDistance = 153;
            splitContainer3.TabIndex = 1;
            // 
            // txtNewpointX
            // 
            txtNewpointX.DecimalPlaces = 2;
            txtNewpointX.Dock = DockStyle.Fill;
            txtNewpointX.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            txtNewpointX.Location = new Point(0, 0);
            txtNewpointX.Maximum = new decimal(new int[] { 1241513974, 370409800, 542101, 0 });
            txtNewpointX.Minimum = new decimal(new int[] { 1241513974, 370409800, 542101, int.MinValue });
            txtNewpointX.Name = "txtNewpointX";
            txtNewpointX.Size = new Size(153, 27);
            txtNewpointX.TabIndex = 0;
            // 
            // txtNewpointY
            // 
            txtNewpointY.DecimalPlaces = 2;
            txtNewpointY.Dock = DockStyle.Fill;
            txtNewpointY.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            txtNewpointY.Location = new Point(0, 0);
            txtNewpointY.Maximum = new decimal(new int[] { 1241513974, 370409800, 542101, 0 });
            txtNewpointY.Minimum = new decimal(new int[] { 1241513974, 370409800, 542101, int.MinValue });
            txtNewpointY.Name = "txtNewpointY";
            txtNewpointY.Size = new Size(166, 27);
            txtNewpointY.TabIndex = 1;
            // 
            // btnAddNewPoint
            // 
            btnAddNewPoint.Dock = DockStyle.Left;
            btnAddNewPoint.Location = new Point(0, 0);
            btnAddNewPoint.Name = "btnAddNewPoint";
            btnAddNewPoint.Size = new Size(94, 29);
            btnAddNewPoint.TabIndex = 0;
            btnAddNewPoint.Text = "Add";
            btnAddNewPoint.UseVisualStyleBackColor = true;
            btnAddNewPoint.Click += btnAddNewPoint_Click;
            // 
            // fplotPoints
            // 
            fplotPoints.BackColor = SystemColors.ButtonHighlight;
            fplotPoints.BorderStyle = BorderStyle.FixedSingle;
            fplotPoints.Dock = DockStyle.Fill;
            fplotPoints.Location = new Point(0, 0);
            fplotPoints.Margin = new Padding(5, 4, 5, 4);
            fplotPoints.Name = "fplotPoints";
            fplotPoints.Size = new Size(588, 361);
            fplotPoints.TabIndex = 0;
            fplotPoints.MouseDown += fplotPoints_MouseDown;
            fplotPoints.MouseMove += fplotPoints_MouseMove;
            // 
            // fplotGneration
            // 
            fplotGneration.BackColor = SystemColors.ButtonHighlight;
            fplotGneration.BorderStyle = BorderStyle.FixedSingle;
            fplotGneration.Dock = DockStyle.Fill;
            fplotGneration.Location = new Point(0, 0);
            fplotGneration.Margin = new Padding(5, 4, 5, 4);
            fplotGneration.Name = "fplotGneration";
            fplotGneration.Size = new Size(1021, 259);
            fplotGneration.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 630);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPoints).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPopulation).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGenerationNumber).EndInit();
            pnlAddPoint.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtNewpointX).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNewpointY).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Panel panel1;
        private ScottPlot.FormsPlot fplotPoints;
        private ScottPlot.FormsPlot fplotGneration;
        private Panel pnlAddPoint;
        private SplitContainer splitContainer3;
        private NumericUpDown txtNewpointX;
        private NumericUpDown txtNewpointY;
        private Button btnAddNewPoint;
        private NumericUpDown txtPopulation;
        private Label label2;
        private NumericUpDown txtGenerationNumber;
        private Label label1;
        private DataGridView dgvPoints;
        private Button btnStart;
    }
}