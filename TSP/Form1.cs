using Core.Domain;
using Core.Domain.Genetic;
using Core.Domain.Genetic.Crossover;
using Core.Domain.Genetic.InitialPopulation;
using Core.Domain.Genetic.Mutation;
using Core.Domain.Genetic.Repair;
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
        private int _plotScale = 650;
        private double _pc = 0.95d, _pm = 0.01d;


        ScatterPlotList<double> _plotPointslist;
        ScatterPlotList<double> _plotGenerationsBstList;
        ScatterPlotList<double> _plotGenerationsAvgList;
        ScatterPlotList<double> _plotGenerationsWstList;
        List<PlotPoint> _pointsList;

        bool _setPoint = false;
        bool _runing = false;

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

            fplotPoints.Plot.AxisAuto();

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
            fplotGneration.Plot.SetAxisLimitsX(0, _plotScale);
            new Thread(async () =>
            {
                btnStart.Invoke(() =>
                {
                    btnAddNewPoint.Enabled = false;
                    btnStart.Text = "STOP";
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

                    ch.ObjectiveFunction = (gs) => TourDistance(gs);

                    ch.FitnessFunction =
                    (genes) =>
                    {
                        //if (!HamiltonPath(genes)) return 0;

                        return (1000d / (1d + TourDistance(genes)));
                    };

                    population.Add(ch);
                }


                //generation
                for (int i = 0; i < generationNumber && _runing; i++)
                {
                    // selection
                    var selected = await GA.Functions.RankSelectionAsync(population);

                    //crossover
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

                        fplotPoints.Plot.Title($"Distance : {best.OF.ToString("0.00")}, Points : {best.Genes.Length}");

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

        private static double TourDistance(PlotPoint[] points)
        {
            double dis = 0.0d;

            for (int i = 1; i < points.Length; i++)
            {
                dis += points[i].Distance(points[i - 1]);
            }

            dis += points[points.Length - 1].Distance(points[0]);

            return dis;
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
            _runing = !_runing;
            if (_runing)
            {
                _plotGenerationsAvgList.Clear();
                _plotGenerationsBstList.Clear();
                _plotGenerationsWstList.Clear();
                fplotGneration.Refresh();
                _runing = true;
                StartTraining();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void txtGenerationNumber_ValueChanged(object sender, EventArgs e)
        {

        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var configureForm = new ConfigureForm(_pc, _pm, _plotScale, this))
            {
                configureForm.ShowDialog();
            }
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