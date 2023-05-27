namespace MagicSquare
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
            btnStart = new Button();
            txtPopulation = new NumericUpDown();
            label3 = new Label();
            txtGenerationNumber = new NumericUpDown();
            label2 = new Label();
            txtLength = new NumericUpDown();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            toolToolStripMenuItem = new ToolStripMenuItem();
            configureToolStripMenuItem = new ToolStripMenuItem();
            dgvSquar = new DataGridView();
            fplotGneration = new ScottPlot.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtPopulation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGenerationNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtLength).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSquar).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
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
            splitContainer1.Size = new Size(959, 671);
            splitContainer1.SplitterDistance = 346;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.BackColor = SystemColors.Window;
            splitContainer2.Panel1.Controls.Add(btnStart);
            splitContainer2.Panel1.Controls.Add(txtPopulation);
            splitContainer2.Panel1.Controls.Add(label3);
            splitContainer2.Panel1.Controls.Add(txtGenerationNumber);
            splitContainer2.Panel1.Controls.Add(label2);
            splitContainer2.Panel1.Controls.Add(txtLength);
            splitContainer2.Panel1.Controls.Add(label1);
            splitContainer2.Panel1.Controls.Add(menuStrip1);
            splitContainer2.Panel1.Margin = new Padding(5);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dgvSquar);
            splitContainer2.Size = new Size(959, 346);
            splitContainer2.SplitterDistance = 527;
            splitContainer2.SplitterWidth = 6;
            splitContainer2.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Dock = DockStyle.Bottom;
            btnStart.Location = new Point(0, 317);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(527, 29);
            btnStart.TabIndex = 6;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtPopulation
            // 
            txtPopulation.Dock = DockStyle.Top;
            txtPopulation.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            txtPopulation.Location = new Point(0, 172);
            txtPopulation.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            txtPopulation.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            txtPopulation.Name = "txtPopulation";
            txtPopulation.Size = new Size(527, 27);
            txtPopulation.TabIndex = 5;
            txtPopulation.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 142);
            label3.Margin = new Padding(3, 5, 3, 5);
            label3.Name = "label3";
            label3.Padding = new Padding(5);
            label3.Size = new Size(97, 30);
            label3.TabIndex = 4;
            label3.Text = "Population :";
            // 
            // txtGenerationNumber
            // 
            txtGenerationNumber.Dock = DockStyle.Top;
            txtGenerationNumber.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            txtGenerationNumber.Location = new Point(0, 115);
            txtGenerationNumber.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            txtGenerationNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtGenerationNumber.Name = "txtGenerationNumber";
            txtGenerationNumber.Size = new Size(527, 27);
            txtGenerationNumber.TabIndex = 3;
            txtGenerationNumber.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(0, 85);
            label2.Margin = new Padding(3, 5, 3, 5);
            label2.Name = "label2";
            label2.Padding = new Padding(5);
            label2.Size = new Size(99, 30);
            label2.TabIndex = 2;
            label2.Text = "Generation :";
            // 
            // txtLength
            // 
            txtLength.Dock = DockStyle.Top;
            txtLength.Location = new Point(0, 58);
            txtLength.Name = "txtLength";
            txtLength.Size = new Size(527, 27);
            txtLength.TabIndex = 1;
            txtLength.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 28);
            label1.Margin = new Padding(3, 5, 3, 5);
            label1.Name = "label1";
            label1.Padding = new Padding(5);
            label1.Size = new Size(71, 30);
            label1.TabIndex = 0;
            label1.Text = "Length :";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(527, 28);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolToolStripMenuItem
            // 
            toolToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configureToolStripMenuItem });
            toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            toolToolStripMenuItem.Size = new Size(52, 24);
            toolToolStripMenuItem.Text = "Tool";
            // 
            // configureToolStripMenuItem
            // 
            configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            configureToolStripMenuItem.Size = new Size(157, 26);
            configureToolStripMenuItem.Text = "Configure";
            configureToolStripMenuItem.Click += configureToolStripMenuItem_Click;
            // 
            // dgvSquar
            // 
            dgvSquar.AllowUserToAddRows = false;
            dgvSquar.AllowUserToDeleteRows = false;
            dgvSquar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSquar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvSquar.BackgroundColor = SystemColors.Window;
            dgvSquar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSquar.Dock = DockStyle.Fill;
            dgvSquar.GridColor = SystemColors.Window;
            dgvSquar.Location = new Point(0, 0);
            dgvSquar.Name = "dgvSquar";
            dgvSquar.ReadOnly = true;
            dgvSquar.RowHeadersWidth = 51;
            dgvSquar.RowTemplate.Height = 29;
            dgvSquar.ShowEditingIcon = false;
            dgvSquar.Size = new Size(426, 346);
            dgvSquar.TabIndex = 0;
            dgvSquar.CellContentClick += dataGridView1_CellContentClick;
            // 
            // fplotGneration
            // 
            fplotGneration.BackColor = SystemColors.Window;
            fplotGneration.Dock = DockStyle.Fill;
            fplotGneration.Location = new Point(0, 0);
            fplotGneration.Margin = new Padding(5, 4, 5, 4);
            fplotGneration.Name = "fplotGneration";
            fplotGneration.Size = new Size(959, 319);
            fplotGneration.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 671);
            Controls.Add(splitContainer1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Magic Square";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtPopulation).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGenerationNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtLength).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSquar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private DataGridView dgvSquar;
        private ScottPlot.FormsPlot fplotGneration;
        private Label label1;
        private NumericUpDown txtPopulation;
        private Label label3;
        private NumericUpDown txtGenerationNumber;
        private Label label2;
        private NumericUpDown txtLength;
        private Button btnStart;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolToolStripMenuItem;
        private ToolStripMenuItem configureToolStripMenuItem;
    }
}