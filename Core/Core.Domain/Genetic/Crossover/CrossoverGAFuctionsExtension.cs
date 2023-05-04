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
                point = new Random().Next(0, parent1.Length);
            }

            int cPoint = (int)point + 1;

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
            double pc)
        {

            if (!parent1.Length.Equals(parent2.Length))
            {
                throw new NonCongenericParentsException();
            }

            Random r = new Random();
            for (int i = 0; i < parent1.Length; i++)
            {
                if (r.NextDouble() < pc)
                {
                    child1.Set(i, parent1.Get(i));
                    child2.Set(i, parent2.Get(i));
                }
                else
                {
                    child1.Set(i, parent2.Get(i));
                    child2.Set(i, parent1.Get(i));
                }
            }
        }

        public static IEnumerable<Chromosome<TGene>> ManyPointCrossover<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> selected, double crossoverProbability)
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
                    ga.ManyPointCrossover(paren1, paren2, ref child1, ref child2, crossoverProbability);
                }

                list.Add(child1);
                list.Add(child2);
            }

            return list;
        }

        // TODO : Add multiplePoint Crossover
    }
}
