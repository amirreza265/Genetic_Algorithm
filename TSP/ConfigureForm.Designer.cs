namespace TSP
{
    partial class ConfigureForm
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
            tbCP = new TrackBar();
            tbMP = new TrackBar();
            txtPlotScale = new NumericUpDown();
            lblCP = new Label();
            lblMP = new Label();
            label3 = new Label();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)tbCP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbMP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPlotScale).BeginInit();
            SuspendLayout();
            // 
            // tbCP
            // 
            tbCP.Location = new Point(12, 32);
            tbCP.Maximum = 100;
            tbCP.Name = "tbCP";
            tbCP.Size = new Size(532, 56);
            tbCP.TabIndex = 0;
            tbCP.ValueChanged += tbCP_ValueChanged;
            // 
            // tbMP
            // 
            tbMP.Location = new Point(12, 123);
            tbMP.Maximum = 100;
            tbMP.Name = "tbMP";
            tbMP.Size = new Size(532, 56);
            tbMP.TabIndex = 1;
            tbMP.ValueChanged += tbMP_ValueChanged;
            // 
            // txtPlotScale
            // 
            txtPlotScale.Location = new Point(99, 185);
            txtPlotScale.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            txtPlotScale.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            txtPlotScale.Name = "txtPlotScale";
            txtPlotScale.Size = new Size(445, 27);
            txtPlotScale.TabIndex = 2;
            txtPlotScale.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // lblCP
            // 
            lblCP.AutoSize = true;
            lblCP.Location = new Point(12, 9);
            lblCP.Name = "lblCP";
            lblCP.Size = new Size(160, 20);
            lblCP.TabIndex = 3;
            lblCP.Text = "Crossover Probability : ";
            // 
            // lblMP
            // 
            lblMP.AutoSize = true;
            lblMP.Location = new Point(12, 100);
            lblMP.Name = "lblMP";
            lblMP.Size = new Size(145, 20);
            lblMP.TabIndex = 4;
            lblMP.Text = "Mutation Probability";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 187);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 5;
            label3.Text = "Plot Scale :";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(450, 225);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ConfigureForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 266);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(lblMP);
            Controls.Add(lblCP);
            Controls.Add(txtPlotScale);
            Controls.Add(tbMP);
            Controls.Add(tbCP);
            MaximumSize = new Size(574, 313);
            MinimizeBox = false;
            MinimumSize = new Size(574, 313);
            Name = "ConfigureForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConfigureForm";
            Load += ConfigureForm_Load;
            ((System.ComponentModel.ISupportInitialize)tbCP).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbMP).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPlotScale).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar tbCP;
        private TrackBar tbMP;
        private NumericUpDown txtPlotScale;
        private Label lblCP;
        private Label lblMP;
        private Label label3;
        private Button btnSave;
    }
}