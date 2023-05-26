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
            txtPopulation = new NumericUpDown();
            label3 = new Label();
            txtGenerationNumber = new NumericUpDown();
            label2 = new Label();
            txtLength = new NumericUpDown();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            formsPlot1 = new ScottPlot.FormsPlot();
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            splitContainer1.Panel2.Controls.Add(formsPlot1);
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
            splitContainer2.Panel1.Controls.Add(txtPopulation);
            splitContainer2.Panel1.Controls.Add(label3);
            splitContainer2.Panel1.Controls.Add(txtGenerationNumber);
            splitContainer2.Panel1.Controls.Add(label2);
            splitContainer2.Panel1.Controls.Add(txtLength);
            splitContainer2.Panel1.Controls.Add(label1);
            splitContainer2.Panel1.Margin = new Padding(5);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dataGridView1);
            splitContainer2.Size = new Size(959, 346);
            splitContainer2.SplitterDistance = 527;
            splitContainer2.SplitterWidth = 6;
            splitContainer2.TabIndex = 0;
            // 
            // txtPopulation
            // 
            txtPopulation.Dock = DockStyle.Top;
            txtPopulation.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            txtPopulation.Location = new Point(0, 144);
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
            label3.Location = new Point(0, 114);
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
            txtGenerationNumber.Location = new Point(0, 87);
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
            label2.Location = new Point(0, 57);
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
            txtLength.Location = new Point(0, 30);
            txtLength.Name = "txtLength";
            txtLength.Size = new Size(527, 27);
            txtLength.TabIndex = 1;
            txtLength.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(3, 5, 3, 5);
            label1.Name = "label1";
            label1.Padding = new Padding(5);
            label1.Size = new Size(71, 30);
            label1.TabIndex = 0;
            label1.Text = "Length :";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(426, 346);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // formsPlot1
            // 
            formsPlot1.BackColor = SystemColors.Window;
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(0, 0);
            formsPlot1.Margin = new Padding(5, 4, 5, 4);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(959, 319);
            formsPlot1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 671);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private DataGridView dataGridView1;
        private ScottPlot.FormsPlot formsPlot1;
        private Label label1;
        private NumericUpDown txtPopulation;
        private Label label3;
        private NumericUpDown txtGenerationNumber;
        private Label label2;
        private NumericUpDown txtLength;
    }
}