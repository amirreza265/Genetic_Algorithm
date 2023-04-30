using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Genetic.Selection
{
    public class SelectionItem<TGene>
    {
        // Probability of being selected
        public double Probability { get; set; }

        public int Rank { get; set; }

        public Chromosome<TGene> Chromosome { get; set; }
    }

    public static class ParentsSelectionGAFunctionsExtension
    {
        public static IEnumerable<Chromosome<TGene>> FPSSelection<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> chromosomes)
        {
            int count = chromosomes.Count();

            if (count <= 1)
            {
                return chromosomes;
            }

            var sum_ff = chromosomes.Sum(c => c.GetFitnessValue());

            var list = new List<SelectionItem<TGene>>();

            //find Probability of eche elements
            var last_p = 0.0d;
            foreach (var chromosome in chromosomes)
            {
                double p = chromosome.GetFitnessValue() / sum_ff;

                var item = new SelectionItem<TGene>()
                {
                    Chromosome = chromosome,
                    Probability = p + last_p,
                };

                list.Add(item);

                last_p = item.Probability;
            }
            var selected = new List<Chromosome<TGene>>();
            var random = new Random();

            // select by Probability as Roulette wheel
            for (int i = 0; i < count; i += 2)
            {
                var first = list.First(item => item.Probability > random.NextDouble());

                var second = list.First();
                do
                {
                    second = list.First(item => item.Probability > random.NextDouble());
                }
                while (first == second);

                selected.Add(first.Chromosome);
                selected.Add(second.Chromosome);
            }

            return selected;
        }

        public static IEnumerable<Chromosome<TGene>> RandomSelection<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> chromosomes)
        {
            int count = chromosomes.Count();

            if (count <= 1)
            {
                return chromosomes;
            }

            var selected = new List<Chromosome<TGene>>();
            var random = new Random();

            for (int i = 0; i < count; i += 2)
            {
                var first = chromosomes.ElementAt(random.Next(0, count));

                var second = chromosomes.ElementAt(random.Next(0, count));


                selected.Add(first);
                selected.Add(second);
            }

            return selected;
        }

        public static IEnumerable<Chromosome<TGene>> TournamentSelection<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> chromosomes, int? K = null)
        {
            int count = chromosomes.Count();

            if (count <= 1)
            {
                return chromosomes;
            }

            var selected = new List<Chromosome<TGene>>();
            var random = new Random();

            if (K is null)
                K = random.Next(1, count);

            for (int i = 0; i < count; i += 2)
            {

                var first = chromosomes.ElementAt(random.Next(0, count));

                var second = chromosomes.ElementAt(random.Next(0, count));


                for (int j = 1; j < K; j++)
                {
                    var randItem = chromosomes.ElementAt(random.Next(0, count));
                    if (first.GetFitnessValue() < randItem.GetFitnessValue())
                        first = randItem;
                }

                for (int j = 1; j < K; j++)
                {
                    var randItem = chromosomes.ElementAt(random.Next(0, count));
                    if (second.GetFitnessValue() < randItem.GetFitnessValue())
                        second = randItem;
                }

                selected.Add(first);
                selected.Add(second);
            }

            return selected;
        }

        public static IEnumerable<Chromosome<TGene>> RankSelection<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> chromosomes)
        {
            int count = chromosomes.Count();

            chromosomes.ToList().Sort((x, y) =>
            {
                var xff= x.GetFitnessValue();
                var yff= y.GetFitnessValue();

                if (xff < yff)
                    return -1;
                else if (xff ==  yff)
                    return 0;
                else
                    return 1;

            });

            if (count <= 1)
            {
                return chromosomes;
            }

            var sum_rank = (count * (count + 1)) / 2;

            var list = new List<SelectionItem<TGene>>();

            var last_rp = 0.0d;
            for (int i = 1; i <= count; i++)
            {
                double rp = (count - i + 1) / sum_rank;

                var item = new SelectionItem<TGene>()
                {
                    Chromosome = chromosomes.ElementAt(i-1),
                    Probability = rp + last_rp,
                };

                list.Add(item);

                last_rp = item.Probability;
            }
            var selected = new List<Chromosome<TGene>>();
            var random = new Random();

            for (int i = 0; i < count; i += 2)
            {
                var first = list.First(item => item.Probability > random.NextDouble());

                var second = list.First();
                do
                {
                    second = list.First(item => item.Probability > random.NextDouble());
                }
                while (first == second);

                selected.Add(first.Chromosome);
                selected.Add(second.Chromosome);
            }

            return selected;
        }

    }
}
