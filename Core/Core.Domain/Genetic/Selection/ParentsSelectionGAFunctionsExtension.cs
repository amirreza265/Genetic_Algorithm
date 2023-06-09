﻿using System;
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
        public static async Task<IEnumerable<Chromosome<TGene>>> FPSSelectionAsync<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> chromosomes, double k = 1)
        {
            int count = chromosomes.Count();

            if (count <= 1)
            {
                return chromosomes;
            }

            if (k <= 0) k = 0;

            var sum_ff = chromosomes.Sum(c => Math.Pow(c.FF, k));

            var list = new List<SelectionItem<TGene>>();

            //find Probability of eche elements
            await Task.Run(() =>
            {
                var last_p = 0.0d;
                foreach (var chromosome in chromosomes)
                {
                    double p = Math.Pow(chromosome.FF, k) / sum_ff;

                    var item = new SelectionItem<TGene>()
                    {
                        Chromosome = chromosome,
                        Probability = p + last_p,
                    };

                    list.Add(item);

                    last_p = item.Probability;
                }
            });
            var selected = new List<Chromosome<TGene>>();
            var random = new Random();


            // select by Probability as Roulette wheel
            await Task.Run(() =>
            {
                for (int i = 0; i < count; i += 2)
                {
                    var first = list.FirstOrDefault(item => item.Probability > random.NextDouble());

                    if (first == null)
                        first = list.ElementAt(random.Next(0, count));

                    var second = list.First();
                    int maxloop = 100;
                    do
                    {
                        second = list.FirstOrDefault(item => item.Probability > random.NextDouble());

                        if (second == null)
                            second = list.ElementAt(random.Next(0, count));

                        maxloop--;
                    }
                    while (first == second && maxloop > 0);

                    if (second == first)
                        second = list.ElementAt(random.Next(0, count));


                    selected.Add(first.Chromosome);
                    selected.Add(second.Chromosome);
                }
            });

            return selected;
        }

        public static async Task<IEnumerable<Chromosome<TGene>>> RandomSelectionAsync<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> chromosomes)
        {
            int count = chromosomes.Count();

            if (count <= 1)
            {
                return chromosomes;
            }

            var selected = new List<Chromosome<TGene>>();
            var random = new Random();
            await Task.Run(() =>
            {
                for (int i = 0; i < count; i += 2)
                {
                    var first = chromosomes.ElementAt(random.Next(0, count));

                    var second = chromosomes.ElementAt(random.Next(0, count));


                    selected.Add(first);
                    selected.Add(second);
                }
            });

            return selected;
        }


        public static async Task<IEnumerable<Chromosome<TGene>>> BestSelectionAsync<TGene>(this GAFunctions ga, List<Chromosome<TGene>> chromosomes)
        {
            int count = chromosomes.Count();

            var sorted = chromosomes.OrderByDescending(x => x.FF);

            var selected = new List<Chromosome<TGene>>();
            var random = new Random();

            await Task.Run(() =>
            {
                for (int i = 0; i < count / 2; i += 2)
                {
                    var first = sorted.ElementAt(i);

                    var second = sorted.ElementAt(i + 1);


                    selected.Add(first);
                    selected.Add(second);
                    selected.Add(first);
                    selected.Add(second);
                }
            });

            return selected;
        }

        public static async Task<IEnumerable<Chromosome<TGene>>> TournamentSelectionAsync<TGene>(
            this GAFunctions ga,
            IEnumerable<Chromosome<TGene>> chromosomes,
            int? K = null)
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

            await Task.Run(() =>
            {
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
            });

            return selected;
        }

        public static async Task<IEnumerable<Chromosome<TGene>>> RankSelectionAsync<TGene>(
            this GAFunctions ga,
            IEnumerable<Chromosome<TGene>> chromosomes)
        {
            int count = chromosomes.Count();

            var sorted = chromosomes.OrderByDescending(x => x.FF);

            if (count <= 1)
            {
                return chromosomes;
            }

            var sum_rank = (count * (count + 1)) / 2;

            var list = new List<SelectionItem<TGene>>();

            await Task.Run(() =>
            {
                var last_rp = 0.0d;
                for (int i = 1; i <= count; i++)
                {
                    double rp = (double)(count - i + 1) / sum_rank;

                    var item = new SelectionItem<TGene>()
                    {
                        Chromosome = sorted.ElementAt(i - 1),
                        Probability = rp + last_rp,
                        Rank = i
                    };

                    list.Add(item);

                    last_rp = item.Probability;
                }
            });

            var selected = new List<Chromosome<TGene>>();
            var random = new Random();

            await Task.Run(() =>
            {
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
            });

            return selected;
        }

    }
}
