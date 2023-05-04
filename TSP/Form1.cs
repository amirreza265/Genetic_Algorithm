using Core.Domain;
using Core.Domain.Genetic;
using Core.Domain.Genetic.Crossover;
using Core.Domain.Genetic.InitialPopulation;
using Core.Domain.Genetic.Mutation;
using Core.Domain.Genetic.Replacement;
using Core.Domain.Genetic.Selection;
using ScottPlot;
using ScottPlot.Plottable;
using System.Net;
using System.Text;
using System.Windows.Forms;
using TSP.Classes;

namespace TSP
{
    public partial class Form1 : Form
    {
        private double _pc = 0.9d, _pm = 0.01d;


        ScatterPlotList<double> _plotPointslist;
        ScatterPlotList<double> _plotGenerationsBstList;
        ScatterPlotList<double> _plotGenerationsAvgList;
        ScatterPlotList<double> _plotGenerationsWstList;
        List<PlotPoint> _pointsList;

        bool _setPoint = false;

        Color _setPointColor = Color.LightGreen;
        Color _defaultPointColor;

        public Form1()
        {
            InitializeComponent();
            _pointsList = new List<PlotPoint>();
        }

        private void btnAddNewPoint_Click(object sender, EventArgs e)
        {
            double x = (double)txtNewpointX.Value;
            double y = (double)txtNewpointY.Value;

            _plotPointslist.Add(x, y);
            _pointsList.Add(new PlotPoint(x, y));

            dgvPoints.DataSource = null;
            dgvPoints.DataSource = _pointsList;

            dgvPoints.Refresh();
            fplotPoints.Refresh();

            if (_pointsList.Count > 0)
            {
                btnStart.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _plotPointslist = fplotPoints.Plot.AddScatterList(lineStyle: LineStyle.None);

            _plotGenerationsBstList = fplotGneration.Plot.AddScatterList(Color.Green, markerShape: MarkerShape.none);
            _plotGenerationsAvgList = fplotGneration.Plot.AddScatterList(Color.Orange, markerShape: MarkerShape.none);
            _plotGenerationsWstList = fplotGneration.Plot.AddScatterList(Color.Red, lineWidth: 0.1f, markerShape: MarkerShape.none, lineStyle: LineStyle.None);

            fplotPoints.Refresh();
            _defaultPointColor = fplotPoints.BackColor;

            dgvPoints.DefaultCellStyle.Format = "#0.00";
            btnStart.Enabled = false;
        }

        private void fplotPoints_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_setPoint)
                return;

            var pos = fplotPoints.GetMouseCoordinates();
            txtNewpointX.Value = (decimal)pos.x;
            txtNewpointY.Value = (decimal)pos.y;
        }

        private void fplotPoints_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnAddNewPoint_Click(sender, e);
        }

        private void fplotPoints_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (_setPoint)
                btnAddNewPoint_Click(sender, e);

            _setPoint = !_setPoint;
            fplotPoints.BackColor = _setPoint ? _setPointColor : _defaultPointColor;
        }

        public void StartTraining()
        {
            new Thread(async () =>
            {
                btnStart.Invoke(() =>
                {
                    btnStart.Enabled = false;
                    btnAddNewPoint.Enabled = false;
                });

                int generationNumber = (int)txtGenerationNumber.Value;
                int populationNumber = (int)txtPopulation.Value;

                var geneCount = _pointsList.Count;
                List<Chromosome<PlotPoint>> population = new();

                Random r = new Random();

                //create random population
                for (int i = 0; i < populationNumber; i++)
                {
                    List<PlotPoint> plotPoints = new(_pointsList);
                    var gense = GA.Functions.RandomInitialPopulation(() =>
                    {
                        int rIndex = r.Next(plotPoints.Count);

                        var point = plotPoints[rIndex];
                        plotPoints.RemoveAt(rIndex);

                        return point;
                    },
                    geneCount);

                    var ch = new Chromosome<PlotPoint>(geneCount, i);
                    ch.Genes = gense;

                    ch.ObjectiveFunction = (gense) =>
                    {
                        double dis = 0.0d;

                        for (int i = 1; i < gense.Length; i++)
                        {
                            dis += gense[i].Distance(gense[i - 1]);
                        }

                        dis += gense[gense.Length - 1].Distance(gense[0]);

                        return dis;
                    };

                    ch.FitnessFunction =
                    (genes) =>
                    {
                        if (!HamiltonPath(genes)) return 0;

                        ////if (ch.OF == 0)
                        ////    return 1;

                        return 1 / ch.OF;
                    };

                    population.Add(ch);
                }


                //generation
                for (int i = 0; i < generationNumber; i++)
                {
                    // selection
                    var selected = await GA.Functions.FPSSelectionAsync(population);

                    //crossover
                    var childs = await GA.Functions.ManyPointCrossoverAsync(selected, _pc);

                    //mutation
                    if (r.NextDouble() > 0.5d)
                        GA.Functions.SwapMutation(childs, _pm);
                    else
                        await GA.Functions.InversionMutation(childs, _pm);

                    ////crossover
                    //childs = GA.Functions.OnePointCrossover(childs, _pc);

                    //replacment
                    //if (r.NextDouble() > 0.5d)
                    await GA.Functions.ReplaceKeepBest(population, childs);
                    //else
                    //    await GA.Functions.ReplaceRank(population, childs);

                    //print best in console
                    var best = population.MaxBy(c => c.FF);
                    var avg = population.Average(c => c.FF);
                    //var min = population.Min(c => c.FF);


                    //show best in point plot 
                    fplotPoints.Invoke(() =>
                    {
                        fplotPoints.Plot.Clear();

                        var xs = best.Genes.Select(g => g.X).ToArray();
                        var ys = best.Genes.Select(g => g.Y).ToArray();

                        fplotPoints.Plot.AddScatter(
                            xs.Append(xs[0]).ToArray(),
                            ys.Append(ys[0]).ToArray());

                        fplotPoints.Refresh();
                    });


                    //show best and avg in plot
                    fplotGneration.Invoke(() =>
                    {
                        _plotGenerationsBstList.Add(i, best.FF);
                        _plotGenerationsAvgList.Add(i, avg);
                        //_plotGenerationsWstList.Add(i, min);

                        fplotPoints.Plot.Title($"Distance : {best.OF.ToString("0.00")}");
                        fplotGneration.Plot.AxisAuto();
                        fplotGneration.Refresh();
                    });
                }

                btnStart.Invoke(() =>
                {
                    btnStart.Enabled = true;
                });

            }).Start();
        }

        private static bool HamiltonPath(PlotPoint[] gense)
        {
            List<PlotPoint> ps = new()
                        {
                            gense[0]
                        };

            for (int i = 1; i < gense.Length; i++)
            {
                if (ps.Any(p => gense[i].Equals(p)))
                    return false;

                ps.Add(gense[i]);
            }

            return true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _plotGenerationsAvgList.Clear();
            _plotGenerationsBstList.Clear();
            _plotGenerationsWstList.Clear();
            fplotGneration.Refresh();
            StartTraining();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void txtGenerationNumber_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}