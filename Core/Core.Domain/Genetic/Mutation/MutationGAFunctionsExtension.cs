using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Genetic.Mutation
{
    public static class MutationGAFunctionsExtension
    {
        public static void SwapMutation<TGene>(this GAFunctions ga, Chromosome<TGene> chromosome, int? position1 = null, int? position2 = null)
        {
            if (chromosome.Length <= 1) return;

            if (chromosome.Length == 2)
            {
                int p1 = 0;
                int p2 = 1;

                var temp = chromosome.Get(p2);
                chromosome.Set(p2, chromosome.Get(p1));
                chromosome.Set(p1, temp);
                return;
            }

            if (position1 is null)
                position1 = new Random().Next(0, chromosome.Length);

            if (position2 is null)
            {
                position2 = position1;

                while (position2 == position1)
                {
                    position2 = new Random().Next(0, chromosome.Length);
                }
            }

            int pos1 = (int)position1;
            int pos2 = (int)position2;

            var tmp = chromosome.Get(pos2);
            chromosome.Set(pos2, chromosome.Get(pos1));
            chromosome.Set(pos1, tmp);
        }

        public static async Task InversionMutationAsync<TGene>(this GAFunctions ga, Chromosome<TGene> chromosome, int? position1 = null, int? position2 = null)
        {
            if (chromosome.Length <= 1) return;

            if (chromosome.Length == 2)
            {
                int p1 = 0;
                int p2 = 1;

                var temp = chromosome.Get(p2);
                chromosome.Set(p2, chromosome.Get(p1));
                chromosome.Set(p1, temp);
                return;
            }

            await Task.Run(() =>
            {
                if (position1 is null)
                    position1 = new Random().Next(0, chromosome.Length);

                if (position2 is null)
                {
                    position2 = position1;

                    while (position2 == position1)
                    {
                        position2 = new Random().Next(0, chromosome.Length);
                    }
                }

                int pos1 = (position1 > position2) ? (int)position1 : (int)position2;
                int pos2 = (position1 > position2) ? (int)position2 : (int)position1;

                var tmp = chromosome.GetSub(pos2, pos1 - pos2);
                tmp = tmp.Reverse().ToArray();
                chromosome.SetRange(tmp, pos2);
            });
        }

        /// <param name="mutationProbability">0 - 1</param>
        public static async Task InversionMutation<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> chromosomes, double mutationProbability)
        {
            var random = new Random();
            foreach (var chromosome in chromosomes)
            {
                if (random.NextDouble() <= mutationProbability)
                {
                   await ga.InversionMutationAsync(chromosome);
                }
            }
        }


        /// <param name="mutationProbability">0 - 1</param>
        public static void SwapMutation<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> chromosomes, double mutationProbability)
        {
            var random = new Random();
            foreach (var chromosome in chromosomes)
            {
                if (random.NextDouble() <= mutationProbability)
                {
                    ga.SwapMutation(chromosome);
                }
            }
        }

        public static void CustomMutation<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> chromosomes, double mutationProbability, Func<TGene[], TGene[]> mutation)
        {
            var random = new Random();
            foreach (var chromosome in chromosomes)
            {
                if (random.NextDouble() <= mutationProbability)
                {
                    var gs = mutation(chromosome.Genes);
                    chromosome.SetRange(gs);
                }
            }
        }


        public static void BitMutation(this GAFunctions ga, Chromosome<bool> chromosome, int? position = null)
        {
            if (chromosome is null)
                position = new Random().Next(0, chromosome.Length);

            bool val = new Random().NextDouble() >= 0.5d;

            chromosome.Set((int)position, val);
        }

        /// <param name="mutationProbability">0 - 1</param>
        public static async Task AllBitMutationAsync(this GAFunctions ga, Chromosome<bool> chromosome, double mutationProbability)
        {
            await Task.Run(() =>
            {
                var r = new Random();
                for (int i = 0; i < chromosome.Length; i++)
                {
                    if (r.NextDouble() < mutationProbability)
                        continue;

                    bool val = r.NextDouble() >= 0.5d;

                    chromosome.Set(i, val);
                }
            });
        }

        /// <param name="mutationProbability">0 - 1</param>
        public static async Task BitMutationAsync(this GAFunctions ga, IEnumerable<Chromosome<bool>> chromosomes, double mutationProbability)
        {
            await Task.Run(() =>
            {
                var random = new Random();
                foreach (var chromosome in chromosomes)
                {
                    if (random.NextDouble() < mutationProbability)
                    {
                        var point = (int)random.NextDouble() * chromosome.Length;
                        ga.BitMutation(chromosome, point);
                    }
                }
            });
        }

        /// <param name="mutationProbability">0 - 1</param>
        public static async void AllBitMutation(this GAFunctions ga, IEnumerable<Chromosome<bool>> chromosomes, double mutationProbability)
        {
            var random = new Random();
            foreach (var chromosome in chromosomes)
            {
                if (random.NextDouble() < mutationProbability)
                {
                    await ga.AllBitMutationAsync(chromosome, mutationProbability);
                }
            }
        }

        public static void BitMutation<TGene>(this GAFunctions ga, Chromosome<TGene> chromosome, int? position = null) where TGene : IComparable, IConvertible, IComparable<TGene>, IEquatable<TGene>, ISpanFormattable
        {
            if (chromosome is null)
                position = new Random().Next(0, chromosome.Length);

            IConvertible val = (new Random().NextDouble() > 0.5d ? 0x00 : 0x01);

            TGene gene = (TGene)val.ToType(typeof(TGene), null);
            chromosome.Set((int)position, gene);
        }


        // TODO : add Displacement , Inversion Mutation
    }
}
