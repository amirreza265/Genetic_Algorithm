using Core.Domain;
using Core.Domain.Genetic;
using Core.Domain.Genetic.Crossover;
using Core.Domain.Genetic.InitialPopulation;
using Core.Domain.Genetic.Mutation;
using Core.Domain.Genetic.Replacement;
using Core.Domain.Genetic.Selection;
using Core.Services.Contracts;
using ScottPlot;
using ScottPlot.Plottable;
using System.Data;
using TSP;

namespace MagicSquare
{
    public partial class Form1 : Form, IGAFormConfigure
    {
        private int _plotScale = 650;
        private double _pc = 0.95d, _pm = 0.01d;

        ScatterPlotList<double> _plotGenerationsBstList;
        ScatterPlotList<double> _plotGenerationsAvgList;

        bool _runing = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _plotGenerationsBstList = fplotGneration.Plot.AddScatterList(Color.Green, markerShape: MarkerShape.none);
            _plotGenerationsAvgList = fplotGneration.Plot.AddScatterList(Color.Orange, markerShape: MarkerShape.none);
        }

        public void StartTraining()
        {
            fplotGneration.Plot.SetAxisLimitsX(0, _plotScale);

            new Thread(async () =>
            {
                btnStart.Invoke(() =>
                {
                    btnStart.Text = "STOP";
                });

                int generationNumber = (int)txtGenerationNumber.Value;
                int populationNumber = (int)txtPopulation.Value;

                var length = (int)txtLength.Value;
                var geneCount = length * length;
                var targetSum = (geneCount * (geneCount + 1)) / (2 * length);

                List<Chromosome<int>> population = new();

                Random r = new Random();

                // create table of numbers
                dgvSquar.Invoke(() =>
                {
                    dgvSquar.Columns.Clear();

                    for (int i = 0; i < length; i++)
                    {
                        dgvSquar.Columns.Add($"number{i}", "");
                    }

                    for (int i = 0; i < length; i++)
                    {
                        dgvSquar.Rows.Add();
                    }
                    dgvSquar.Refresh();
                });

                //create random population
                for (int i = 0; i < populationNumber; i++)
                {
                    List<int> numList = Enumerable.Range(1, geneCount).ToList();
                    var gense = GA.Functions.RandomInitialPopulation(() =>
                    {
                        int rIndex = r.Next(numList.Count);

                        var num = numList[rIndex];
                        numList.RemoveAt(rIndex);

                        return num;
                    },
                    geneCount);

                    var ch = new Chromosome<int>(geneCount, i);
                    ch.Genes = gense;

                    // add of
                    ch.ObjectiveFunction = (gs) => ObjectiveFunction(gs);

                    // add ff
                    ch.FitnessFunction =
                    (genes) =>
                    {
                        return (1d / (1d + ObjectiveFunction(genes)));
                    };

                    population.Add(ch);

                    double ObjectiveFunction(int[] gs)
                    {
                        int[] rowsSum = new int[length];
                        int[] columnsSum = new int[length];

                        int mainDiameter = 0;
                        int secondDiameter = 0;

                        for (int i = 0; i < length; i++)
                            for (int j = 0; j < length; j++)
                            {
                                int numIndex = (i * length) + j;

                                rowsSum[i] += gs[numIndex];
                                columnsSum[j] += gs[numIndex];

                                if (i == j)
                                    mainDiameter += gs[numIndex];
                                else if ((i + j + 1) == length)
                                    secondDiameter += gs[numIndex];
                            }

                        var rowErr = Math.Abs(rowsSum.Sum() - targetSum);
                        var colErr = Math.Abs(columnsSum.Sum() - targetSum);
                        var mdErr = Math.Abs(mainDiameter - targetSum);
                        var sd = Math.Abs(secondDiameter - targetSum);

                        return rowErr + colErr + mdErr + sd;
                    }
                }


                //generation
                for (int i = 0; i < generationNumber && _runing; i++)
                {
                    // selection
                    var selected = await GA.Functions.RankSelectionAsync(population);

                    //crossover
                    //int pointCount = (geneCount < 4) ? 1 : r.Next(1, geneCount / 2);
                    var childs = await GA.Functions.CleverCrossoverAsync(selected, _pc);

                    //mutation
                    var rd = r.NextDouble();
                    if (rd > 0.66d)
                        GA.Functions.SwapMutation(childs, _pm);
                    else if (rd > 0.33)
                        await GA.Functions.InversionMutation(childs, _pm);
                    else
                        await GA.Functions.DisplacementMutation(childs, _pm);


                    //crossover
                    childs = await GA.Functions.CleverCrossoverAsync(selected, _pc);



                    //replacment
                    await GA.Functions.ReplaceKeepBest(population, childs);

                    //print best in console
                    var best = population.MaxBy(c => c.FF);
                    var avg = population.Average(c => c.FF);
                    //var min = population.Min(c => c.FF);


                    //show best in dgvNumbers `1
                    dgvSquar.Invoke(() =>
                    {
                        for (int i = 0; i < length; i++)
                            for (int j = 0; j < length; j++)
                            {
                                int itemIndex = i * length + j;
                                dgvSquar.Rows[i].Cells[j].Value = best?.Genes[itemIndex];
                            }

                        dgvSquar.Refresh();
                    });


                    //show best and avg in plot
                    fplotGneration.Invoke(() =>
                    {
                        _plotGenerationsBstList.Add(i, best.FF);
                        _plotGenerationsAvgList.Add(i, avg);
                        //_plotGenerationsWstList.Add(i, min);


                        if (i > _plotScale)
                            fplotGneration.Plot.SetAxisLimitsX(i - _plotScale, i + 10);

                        fplotGneration.Plot.AxisAutoY();
                        fplotGneration.Refresh();
                    });
                }

                btnStart.Invoke(() =>
                {
                    btnStart.Text = "Start";
                    _runing = false;
                });

            }).Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _runing = !_runing;
            if (_runing)
            {
                _plotGenerationsAvgList.Clear();
                _plotGenerationsBstList.Clear();

                fplotGneration.Refresh();
                _runing = true;
                StartTraining();
            }
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var configureForm = new ConfigureForm(_pc, _pm, _plotScale, this);
            configureForm.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pm">1 -- 100</param>
        /// <param name="pc">1 -- 100</param>
        /// <param name="plotScale"></param>
        public void SetValues(int pm = 5, int pc = 95, int plotScale = 800)
        {
            _plotScale = plotScale;
            _pm = pm / 100d;
            _pc = pc / 100d;
        }
    }
}