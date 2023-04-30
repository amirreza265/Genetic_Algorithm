using Core.Domain;
using Core.Domain.Genetic;
using Core.Domain.Genetic.InitialPopulation;
using Genetic_Algorithm.Classes;
using Genetic_Algorithm.Extensions;

namespace Genetic_Algorithm
{
    public partial class Form1 : Form
    {
        List<KnapsackItem> _knapsackItems;
        public Form1()
        {
            InitializeComponent();
            _knapsackItems = new List<KnapsackItem>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvKnapsackItems.DataSource = _knapsackItems;
        }

        public void ConsoleLog(string message)
        {
            txtConsole.Invoke(() =>
            {
                txtConsole.AppendText(message, Color.Black);
            });
        }

        public void ConsoleLog(string message, Color logColor)
        {
            txtConsole.Invoke(() =>
            {
                txtConsole.AppendText(message, logColor);
            });
        }

        private void StartTraining()
        {
            new Thread(() =>
            {
                long generationNumber = (long)txtGenerationNumber.Value;

                var random = new Random();
                var p = GA.Functions.RandomInitialPopulation(
                    () => random.NextDouble() >= 0.5d,
                    (int)txtInitCount.Value
                );



            }).Start();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var w = (int)txtWeight.Value;
            var p = (int)txtProfit.Value;

            var item = new KnapsackItem
            {
                Weigth = w,
                Profit = p,
            };

            //TODO : Add Item to dgv
            _knapsackItems.Add(item);
            dgvKnapsackItems.DataSource = null;
            dgvKnapsackItems.DataSource = _knapsackItems;
        }
    }
}