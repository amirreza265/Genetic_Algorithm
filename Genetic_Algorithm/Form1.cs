using Core.Domain;
using Core.Domain.Genetic;
using Core.Domain.Genetic.Crossover;
using Core.Domain.Genetic.InitialPopulation;
using Core.Domain.Genetic.Mutation;
using Core.Domain.Genetic.Replacement;
using Core.Domain.Genetic.Selection;
using Genetic_Algorithm.Classes;
using Genetic_Algorithm.Extensions;
using ScottPlot.Plottable;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Genetic_Algorithm
{
    public partial class Form1 : Form
    {
        List<KnapsackItem> _knapsackItems;
        ScatterPlotList<double> _scatterPlotBstList;
        ScatterPlotList<double> _scatterPlotAvgList;


        private double _pc = 0.85;
        private double _pm = 0.01;

        private double _alpha = 0.3;
        private double _beta = 0.7;

        private int _scale = 500;

        public Form1()
        {
            InitializeComponent();
            _knapsackItems = new List<KnapsackItem>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvKnapsackItems.DataSource = _knapsackItems;
            dgvKnapsackItems_SelectionChanged(null, null);
            _scatterPlotBstList = formsPlot1.Plot.AddScatterList(Color.Green, markerShape: ScottPlot.MarkerShape.none);
            _scatterPlotAvgList = formsPlot1.Plot.AddScatterList(Color.Orange, markerShape: ScottPlot.MarkerShape.none);
        }

        public void ConsoleLog(string message)
        {
            txtConsole.Invoke(() =>
            {
                txtConsole.AppendText(message, Color.Black);
                txtConsole.ScrollToCaret();
            });
        }

        public void ConsoleLog(string message, Color logColor)
        {
            txtConsole.Invoke(() =>
            {
                txtConsole.AppendText(message, logColor);
                txtConsole.ScrollToCaret();
            });
        }

        private void StartTraining()
        {
            long generationNumber = (long)txtGenerationNumber.Value;
            long knapsackMax = (long)txtKnapSackMax.Value;

            var random = new Random();

            var initCount = (long)txtInitCount.Value;
            var geneCount = _knapsackItems.Count;
            var population = new List<Chromosome<bool>>();

            formsPlot1.Plot.SetAxisLimitsX(0, _scale);
            formsPlot1.Refresh();

            new Thread(async () =>
            {
                //create random population
                SetPbarMax((int)initCount);
                for (int i = 0; i < initCount; i++)
                {
                    var genes = GA.Functions.RandomInitialPopulation(() => random.NextDouble() > 0.5d,
                        (gs) =>
                        {
                            int profit = 0;
                            int weigth = 0;
                            GetProfitAndWeight(gs, out profit, out weigth);
                            return weigth <= knapsackMax;
                        }
                        , geneCount);

                    var ch = new Chromosome<bool>(geneCount);
                    ch.Genes = genes;
                    ch.ObjectiveFunction = (gs) => GetOFValue(knapsackMax, gs);

                    ch.FitnessFunction = (gs) => GetOFValue(knapsackMax, gs);

                    population.Add(ch);

                    menuStrip1.Invoke(() =>
                    {
                        lblGeneratIonInfo.Text = $"Population {i + 1}";
                        pbarGenerationProgress.Value = i + 1;
                    });
                }

                //generation
                SetPbarMax((int)generationNumber);
                for (int i = 0; i < generationNumber; i++)
                {
                    // selection
                    var selected = await GA.Functions.FPSSelectionAsync(population);

                    //crossover
                    int pointCount = (geneCount < 4) ? 1 : random.Next(0, geneCount / 2);
                    var childs = await GA.Functions.ManyPointCrossoverAsync(selected, _pc, pointCount);

                    //mutation
                    await GA.Functions.BitMutationAsync(childs, _pm);

                    //crossover
                    //childs = GA.Functions.OnePointCrossover(childs, _pc);

                    //replacment
                    await GA.Functions.ReplaceKeepBest(population, childs);

                    //print best in console
                    var best = population.MaxBy(c => c.GetFitnessValue());

                    StringBuilder str = new StringBuilder();
                    foreach (var gene in best.Genes)
                    {
                        int use = gene ? 1 : 0;
                        str.Append($"{use},");
                    }
                    int profit = 0;
                    int weigth = 0;
                    GetProfitAndWeight(best.Genes, out profit, out weigth);
                    var avgFf = population.Average(c => c.GetFitnessValue());
                    ConsoleLog($"gn{i + 1} , [{str}] , ff :{best.GetFitnessValue()}, avg : {avgFf}, p :{profit}, w :{weigth} \n");

                    menuStrip1.Invoke(() =>
                    {
                        lblGeneratIonInfo.Text = $"Generation {i + 1}";
                        pbarGenerationProgress.Value = i + 1;
                        _scatterPlotBstList.Add(i, best.FF);
                        _scatterPlotAvgList.Add(i, avgFf);

                        formsPlot1.Plot.SetAxisLimitsX(i - _scale, i + 10);
                        formsPlot1.Plot.AxisAutoY();
                        formsPlot1.Refresh();
                    });
                }

            }).Start();
        }

        private double GetOFValue(long knapsackMax, bool[] genes)
        {
            // alpha * (profit / sum(profits)) + beta * (max - w) / sum(w)
            int profit, weigth;
            GetProfitAndWeight(genes, out profit, out weigth);

            if (weigth > knapsackMax)
                return 0;

            return profit;
        }

        private void GetProfitAndWeight(bool[] genes, out int profit, out int weigth)
        {
            profit = 0;
            weigth = 0;
            for (int j = 0; j < genes.Length; j++)
            {
                if (genes[j])
                {
                    profit += _knapsackItems[j].Profit;
                    weigth += _knapsackItems[j].Weigth;
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var w = (int)txtWeight.Value;
            var p = (int)txtProfit.Value;

            var item = new KnapsackItem
            {
                Weigth = w,
                Profit = p,
                Id = _knapsackItems.Count + 1
            };

            //TODO : Add Item to dgv
            _knapsackItems.Add(item);
            dgvKnapsackItems.DataSource = null;
            dgvKnapsackItems.DataSource = _knapsackItems;
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            var selected = (int)dgvKnapsackItems.SelectedRows[0].Cells[0].Value;

            _knapsackItems.Remove(_knapsackItems.First(i => i.Id == selected));
        }

        private void dgvKnapsackItems_SelectionChanged(object sender, EventArgs e)
        {
            btnRemoveItem.Enabled = dgvKnapsackItems.SelectedRows.Count > 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
            _scatterPlotAvgList.Clear();
            _scatterPlotBstList.Clear();
            formsPlot1.Refresh();
            StartTraining();
        }

        private void txtGenerationNumber_ValueChanged(object sender, EventArgs e)
        {
        }

        private void SetPbarMax(int value)
        {
            menuStrip1.Invoke(() =>
                pbarGenerationProgress.Maximum = value
            );
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void formsPlot1_RegionChanged(object sender, EventArgs e)
        {
            formsPlot1.Plot.AxisAutoY();
        }
    }
}