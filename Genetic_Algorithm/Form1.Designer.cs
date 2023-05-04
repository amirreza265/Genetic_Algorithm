namespace Genetic_Algorithm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new SplitContainer();
            tabControl = new TabControl();
            tpInputs = new TabPage();
            panel1 = new Panel();
            panel2 = new Panel();
            splitContainer2 = new SplitContainer();
            btnAddItem = new Button();
            btnRemoveItem = new Button();
            txtWeight = new NumericUpDown();
            label3 = new Label();
            txtProfit = new NumericUpDown();
            label4 = new Label();
            dgvKnapsackItems = new DataGridView();
            txtKnapSackMax = new NumericUpDown();
            label5 = new Label();
            txtInitCount = new NumericUpDown();
            label2 = new Label();
            txtGenerationNumber = new NumericUpDown();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            lblGeneratIonInfo = new ToolStripStatusLabel();
            pbarGenerationProgress = new ToolStripProgressBar();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            btnStart = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            tpFFChart = new TabPage();
            formsPlot1 = new ScottPlot.FormsPlot();
            txtConsole = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl.SuspendLayout();
            tpInputs.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProfit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvKnapsackItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKnapSackMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtInitCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGenerationNumber).BeginInit();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            tpFFChart.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(tabControl);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtConsole);
            splitContainer1.Size = new Size(961, 622);
            splitContainer1.SplitterDistance = 493;
            splitContainer1.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tpInputs);
            tabControl.Controls.Add(tpFFChart);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(961, 493);
            tabControl.TabIndex = 0;
            // 
            // tpInputs
            // 
            tpInputs.Controls.Add(panel1);
            tpInputs.Controls.Add(txtKnapSackMax);
            tpInputs.Controls.Add(label5);
            tpInputs.Controls.Add(txtInitCount);
            tpInputs.Controls.Add(label2);
            tpInputs.Controls.Add(txtGenerationNumber);
            tpInputs.Controls.Add(label1);
            tpInputs.Controls.Add(statusStrip1);
            tpInputs.Controls.Add(menuStrip1);
            tpInputs.Location = new Point(4, 29);
            tpInputs.Name = "tpInputs";
            tpInputs.Padding = new Padding(3);
            tpInputs.Size = new Size(953, 460);
            tpInputs.TabIndex = 0;
            tpInputs.Text = "Inputs";
            tpInputs.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 172);
            panel1.Name = "panel1";
            panel1.Size = new Size(947, 259);
            panel1.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(splitContainer2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(943, 255);
            panel2.TabIndex = 7;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(btnAddItem);
            splitContainer2.Panel1.Controls.Add(btnRemoveItem);
            splitContainer2.Panel1.Controls.Add(txtWeight);
            splitContainer2.Panel1.Controls.Add(label3);
            splitContainer2.Panel1.Controls.Add(txtProfit);
            splitContainer2.Panel1.Controls.Add(label4);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dgvKnapsackItems);
            splitContainer2.Size = new Size(939, 251);
            splitContainer2.SplitterDistance = 312;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 0;
            // 
            // btnAddItem
            // 
            btnAddItem.Dock = DockStyle.Bottom;
            btnAddItem.Location = new Point(0, 193);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(312, 29);
            btnAddItem.TabIndex = 7;
            btnAddItem.Text = "Add";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.Dock = DockStyle.Bottom;
            btnRemoveItem.Location = new Point(0, 222);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(312, 29);
            btnRemoveItem.TabIndex = 6;
            btnRemoveItem.Text = "Remove";
            btnRemoveItem.UseVisualStyleBackColor = true;
            btnRemoveItem.Click += btnRemoveItem_Click;
            // 
            // txtWeight
            // 
            txtWeight.Dock = DockStyle.Top;
            txtWeight.Location = new Point(0, 67);
            txtWeight.Maximum = new decimal(new int[] { 9999990, 0, 0, 0 });
            txtWeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(312, 27);
            txtWeight.TabIndex = 4;
            txtWeight.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 47);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 2;
            label3.Text = "weight :";
            // 
            // txtProfit
            // 
            txtProfit.Dock = DockStyle.Top;
            txtProfit.Location = new Point(0, 20);
            txtProfit.Maximum = new decimal(new int[] { 9999990, 0, 0, 0 });
            txtProfit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtProfit.Name = "txtProfit";
            txtProfit.Size = new Size(312, 27);
            txtProfit.TabIndex = 5;
            txtProfit.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 3;
            label4.Text = "Profit :";
            // 
            // dgvKnapsackItems
            // 
            dgvKnapsackItems.AllowUserToAddRows = false;
            dgvKnapsackItems.AllowUserToDeleteRows = false;
            dgvKnapsackItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKnapsackItems.ColumnHeadersHeight = 29;
            dgvKnapsackItems.Dock = DockStyle.Fill;
            dgvKnapsackItems.Location = new Point(0, 0);
            dgvKnapsackItems.Name = "dgvKnapsackItems";
            dgvKnapsackItems.ReadOnly = true;
            dgvKnapsackItems.RowHeadersWidth = 51;
            dgvKnapsackItems.RowTemplate.Height = 29;
            dgvKnapsackItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKnapsackItems.Size = new Size(622, 251);
            dgvKnapsackItems.TabIndex = 0;
            // 
            // txtKnapSackMax
            // 
            txtKnapSackMax.Dock = DockStyle.Top;
            txtKnapSackMax.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            txtKnapSackMax.Location = new Point(3, 145);
            txtKnapSackMax.Maximum = new decimal(new int[] { -1530494986, 232830, 0, 0 });
            txtKnapSackMax.Name = "txtKnapSackMax";
            txtKnapSackMax.Size = new Size(947, 27);
            txtKnapSackMax.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Location = new Point(3, 125);
            label5.Name = "label5";
            label5.Size = new Size(110, 20);
            label5.TabIndex = 12;
            label5.Text = "Max Knapsack :";
            // 
            // txtInitCount
            // 
            txtInitCount.Dock = DockStyle.Top;
            txtInitCount.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            txtInitCount.Location = new Point(3, 98);
            txtInitCount.Maximum = new decimal(new int[] { -1530494986, 232830, 0, 0 });
            txtInitCount.Name = "txtInitCount";
            txtInitCount.Size = new Size(947, 27);
            txtInitCount.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(3, 78);
            label2.Name = "label2";
            label2.Size = new Size(171, 20);
            label2.TabIndex = 4;
            label2.Text = "Initial Population Count :";
            // 
            // txtGenerationNumber
            // 
            txtGenerationNumber.Dock = DockStyle.Top;
            txtGenerationNumber.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            txtGenerationNumber.Location = new Point(3, 51);
            txtGenerationNumber.Maximum = new decimal(new int[] { -1530494986, 232830, 0, 0 });
            txtGenerationNumber.Name = "txtGenerationNumber";
            txtGenerationNumber.Size = new Size(947, 27);
            txtGenerationNumber.TabIndex = 3;
            txtGenerationNumber.ValueChanged += txtGenerationNumber_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(3, 31);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 2;
            label1.Text = "Generation number :";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblGeneratIonInfo, pbarGenerationProgress, toolStripDropDownButton1 });
            statusStrip1.Location = new Point(3, 431);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(947, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblGeneratIonInfo
            // 
            lblGeneratIonInfo.Name = "lblGeneratIonInfo";
            lblGeneratIonInfo.Size = new Size(26, 20);
            lblGeneratIonInfo.Text = "gn";
            // 
            // pbarGenerationProgress
            // 
            pbarGenerationProgress.Name = "pbarGenerationProgress";
            pbarGenerationProgress.Size = new Size(100, 18);
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { btnStart });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(34, 24);
            toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // btnStart
            // 
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(224, 26);
            btnStart.Text = "Start";
            btnStart.Click += btnStart_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem });
            menuStrip1.Location = new Point(3, 3);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(947, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(58, 24);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // tpFFChart
            // 
            tpFFChart.Controls.Add(formsPlot1);
            tpFFChart.Location = new Point(4, 29);
            tpFFChart.Name = "tpFFChart";
            tpFFChart.Padding = new Padding(3);
            tpFFChart.Size = new Size(953, 460);
            tpFFChart.TabIndex = 1;
            tpFFChart.Text = "Charts";
            tpFFChart.UseVisualStyleBackColor = true;
            // 
            // formsPlot1
            // 
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(3, 3);
            formsPlot1.Margin = new Padding(5, 4, 5, 4);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(947, 454);
            formsPlot1.TabIndex = 0;
            // 
            // txtConsole
            // 
            txtConsole.Dock = DockStyle.Fill;
            txtConsole.Location = new Point(0, 0);
            txtConsole.Name = "txtConsole";
            txtConsole.Size = new Size(961, 125);
            txtConsole.TabIndex = 0;
            txtConsole.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 622);
            Controls.Add(splitContainer1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "GeneticAlgorithm";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tpInputs.ResumeLayout(false);
            tpInputs.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProfit).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvKnapsackItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKnapSackMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtInitCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGenerationNumber).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tpFFChart.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private RichTextBox txtConsole;
        private TabControl tabControl;
        private TabPage tpInputs;
        private TabPage tpFFChart;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblGeneratIonInfo;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripProgressBar pbarGenerationProgress;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private NumericUpDown txtGenerationNumber;
        private Label label1;
        private ToolStripMenuItem btnStart;
        private NumericUpDown txtInitCount;
        private Label label2;
        private Panel panel1;
        private NumericUpDown txtKnapSackMax;
        private Label label5;
        private Panel panel2;
        private SplitContainer splitContainer2;
        private Button btnAddItem;
        private Button btnRemoveItem;
        private NumericUpDown txtWeight;
        private Label label3;
        private NumericUpDown txtProfit;
        private Label label4;
        private DataGridView dgvKnapsackItems;
        private ScottPlot.FormsPlot formsPlot1;
    }
}