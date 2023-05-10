using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSP
{
    public partial class ConfigureForm : Form
    {
        private int _plotScale = 650;
        private double _pc = 0.95d, _pm = 0.01d;
        private Form1 _form1;

        public ConfigureForm(double pc, double pm, int plotScale, Form1 form1)
        {
            InitializeComponent();
            _pc = pc;
            _pm = pm;
            _plotScale = plotScale;
            _form1 = form1;
        }

        public ConfigureForm()
        {
            InitializeComponent();
        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {
            tbCP.Value = (int)(_pc * 100);
            tbMP.Value = (int)(_pm * 100);
            txtPlotScale.Value = _plotScale;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _form1.SetValues(tbMP.Value, tbCP.Value, (int)txtPlotScale.Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void tbCP_ValueChanged(object sender, EventArgs e)
        {
            lblCP.Text = $"Crossover Probability : {tbCP.Value.ToString()}%";
        }

        private void tbMP_ValueChanged(object sender, EventArgs e)
        {
            lblMP.Text = $"Mutation Probability : {tbMP.Value.ToString()}%";
        }
    }
}
