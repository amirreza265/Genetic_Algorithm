using Core.Domain.Genetic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Genetic.Crossover
{
    public static class CrossoverGAFuctionsExtension
    {
        public static void OnePointCrossover<TGene>(this GAFunctions ga,
            Chromosome<TGene> parent1,
            Chromosome<TGene> parent2,
            ref Chromosome<TGene> child1,
            ref Chromosome<TGene> child2,
            int? point = null)
        {

            if (!parent1.Length.Equals(parent2.Length))
            {
                throw new NonCongenericParentsException();
            }

            if (point is null)
            {
                point = new Random().Next(1, parent1.Length);
            }

            OnePointCrossover(parent1, parent2, child1, child2, point);
        }

        private static void OnePointCrossover<TGene>(Chromosome<TGene> parent1, Chromosome<TGene> parent2, Chromosome<TGene> child1, Chromosome<TGene> child2, int? point)
        {
            int cPoint = (int)point;

            // set child 1
            child1.SetRange(parent1.GetSub(0, cPoint));
            child1.SetRange(parent2.GetSub(cPoint, child1.Length - cPoint), cPoint);

            // set child 2
            child2.SetRange(parent2.GetSub(0, cPoint));
            child2.SetRange(parent1.GetSub(cPoint, child2.Length - cPoint), cPoint);
        }

        public static IEnumerable<Chromosome<TGene>> OnePointCrossover<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> selected, double crossoverProbability)
        {
            int count = selected.Count();
            List<Chromosome<TGene>> list = new List<Chromosome<TGene>>();

            if (count <= 1)
                return selected;

            var random = new Random();
            for (int i = 0; i < count; i += 2)
            {
                Chromosome<TGene> paren1 = selected.ElementAt(i);
                Chromosome<TGene> paren2 = selected.ElementAt(i + 1);

                var child1 = paren1.Copy();
                var child2 = paren2.Copy();


                var r = random.NextDouble();

                if (r <= crossoverProbability)
                {
                    int point = (int)(random.NextDouble() * paren1.Length);
                    ga.OnePointCrossover(paren1, paren2, ref child1, ref child2, point);
                }

                list.Add(child1);
                list.Add(child2);
            }

            return list;
        }

        public static void ManyPointCrossover<TGene>(this GAFunctions ga,
            Chromosome<TGene> parent1,
            Chromosome<TGene> parent2,
            ref Chromosome<TGene> child1,
            ref Chromosome<TGene> child2,
            double pc,
            int[] points)
        {

            if (!parent1.Length.Equals(parent2.Length))
            {
                throw new NonCongenericParentsException();
            }

            points = points.OrderBy(p => p).ToArray();

            Random r = new Random();
            int lastPoint = 0;
            bool cross = true;
            for (int i = 0; i < points.Length; i++)
            {
                if (cross)
                {
                    child1.SetRange(parent2.GetSub(lastPoint, points[i] - lastPoint), lastPoint);
                    child2.SetRange(parent1.GetSub(lastPoint, points[i] - lastPoint), lastPoint);
                }

                cross = !cross;
            }
        }

        public static async Task<IEnumerable<Chromosome<TGene>>> ManyPointCrossoverAsync<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> selected, double crossoverProbability, int pointCount = 2)
        {
            int count = selected.Count();
            List<Chromosome<TGene>> list = new List<Chromosome<TGene>>();

            if (count <= 1)
                return selected;

            var random = new Random();
            await Task.Run(() =>
            {
                for (int i = 0; i < count - 1; i += 2)
                {
                    Chromosome<TGene> paren1 = selected.ElementAt(i);
                    Chromosome<TGene> paren2 = selected.ElementAt(i + 1);

                    var child1 = paren1.Copy();
                    var child2 = paren2.Copy();


                    var r = random.NextDouble();

                    if (r <= crossoverProbability)
                    {
                        List<int> points = new List<int>();

                        for (int j = 0; j < pointCount; j++)
                        {
                            points.Add(random.Next(1, paren1.Length));
                        }

                        ga.ManyPointCrossover(paren1, paren2, ref child1, ref child2, crossoverProbability, points.ToArray());
                    }

                    list.Add(child1);
                    list.Add(child2);
                }
            });

            return list;
        }


        public static async Task<IEnumerable<Chromosome<TGene>>> ManyPointCrossoverRepairAsync<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> selected, double crossoverProbability, Func<TGene[], TGene[]> repair, int pointCount = 2)
        {
            int count = selected.Count();
            List<Chromosome<TGene>> list = new List<Chromosome<TGene>>();

            if (count <= 1)
                return selected;

            var random = new Random();
            await Task.Run(() =>
            {
                for (int i = 0; i < count - 1; i += 2)
                {
                    Chromosome<TGene> paren1 = selected.ElementAt(i);
                    Chromosome<TGene> paren2 = selected.ElementAt(i + 1);

                    var child1 = paren1.Copy();
                    var child2 = paren2.Copy();


                    var r = random.NextDouble();

                    if (r <= crossoverProbability)
                    {
                        List<int> points = new List<int>();

                        for (int j = 0; j < pointCount; j++)
                        {
                            points.Add(random.Next(1, paren1.Length));
                        }

                        ga.ManyPointCrossover(paren1, paren2, ref child1, ref child2, crossoverProbability, points.ToArray());
                        child1.SetRange(repair(child1.Genes));
                        child2.SetRange(repair(child2.Genes));
                    }

                    list.Add(child1);
                    list.Add(child2);
                }
            });

            return list;
        }


        public static void CleverCrossover<TGene>(this GAFunctions ga,
            Chromosome<TGene> parent1,
            Chromosome<TGene> parent2,
            ref Chromosome<TGene> child1,
            ref Chromosome<TGene> child2)
        {
            if (!parent1.Length.Equals(parent2.Length))
            {
                throw new NonCongenericParentsException();
            }

            var p1Copy = parent1.Genes.ToList();
            var p2Copy = parent2.Genes.ToList();

            var r = new Random();

            int point1 = r.Next(0, p1Copy.Count - 1);
            int point2 = r.Next(point1, p2Copy.Count);
            int count = point2 - point1 + 1;

            for (int i = 0; i < parent1.Length; i++)
            {
                //add some gene that should not moved
                if (i < count)
                {
                    var p1GeneI = parent1.Get(i + point1);
                    var p2GeneI = parent2.Get(i + point1);
                    child1.Set(i, p1GeneI);
                    child2.Set(i, p2GeneI);

                    p1Copy.Remove(p2GeneI);
                    p2Copy.Remove(p1GeneI);

                    continue;
                }

                child1.Set(i, p2Copy.First());
                p2Copy.RemoveAt(0);

                child2.Set(i, p1Copy.First());
                p1Copy.RemoveAt(0);
            }

        }

        public static async Task<IEnumerable<Chromosome<TGene>>> CleverCrossoverAsync<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> selected, double crossoverProbability)
        {
            int count = selected.Count();
            List<Chromosome<TGene>> list = new List<Chromosome<TGene>>();

            if (count <= 1)
                return selected;

            var random = new Random();
            await Task.Run(() =>
            {
                for (int i = 0; i < count; i += 2)
                {
                    Chromosome<TGene> paren1 = selected.ElementAt(i);
                    Chromosome<TGene> paren2 = selected.ElementAt(i + 1);

                    var child1 = paren1.Copy();
                    var child2 = paren2.Copy();


                    var r = random.NextDouble();

                    if (r <= crossoverProbability)
                    {
                        ga.CleverCrossover(paren1, paren2, ref child1, ref child2);
                    }

                    list.Add(child1);
                    list.Add(child2);
                }
            });

            return list;
        }
    }
}
