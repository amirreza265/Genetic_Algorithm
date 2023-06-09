﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Genetic.Replacement
{
    public static class ReplacementGAFunctionsExtensions
    {
        public static async Task ReplaceKeepBest<TGene>(
            this GAFunctions ga,
            List<Chromosome<TGene>> parents,
            IEnumerable<Chromosome<TGene>> childs)
        {
            var count = parents.Count();

            Random r = new Random();

            await Task.Run(async () =>
            {
                Chromosome<TGene> bestParent = parents.MaxBy(c => c.FF);
                Chromosome<TGene> bestchild = childs.MaxBy(c => c.FF);

                parents[0] = bestchild.FF > bestParent.FF ? bestchild : bestParent;
                //parents[1] = bestchild.FF > bestParent.FF ? bestchild : bestParent;

                //parents[0] = bestParent;
                //parents[1] = bestchild;

                await Task.Run(() =>
                {
                    for (int k = 1; k < count; k++)
                    {
                        parents[k] = childs.ElementAt(k);
                    }
                });
            });
        }

        public static async Task<IEnumerable<Chromosome<TGene>>> ReplaceRank<TGene>(
            this GAFunctions ga,
            List<Chromosome<TGene>> parents,
            IEnumerable<Chromosome<TGene>> childs)
        {
            await Task.Run(() =>
            {
                var count = parents.Count();

                parents.AddRange(childs);

                parents = parents
                    .OrderByDescending(c => c.FF)
                    .Take(count)
                    .ToList();
            });

            return parents;
        }

        public static async Task ReplaceRandom<TGene>(
            this GAFunctions ga,
            List<Chromosome<TGene>> parents,
            IEnumerable<Chromosome<TGene>> childs)
        {
            var count = parents.Count();

            await Task.Run(() =>
            {
                Random r = new Random();

                for (int k = 0; k < count; k++)
                {
                    if (r.NextDouble() > 0.5)
                        parents[k] = childs.ElementAt(k);
                }
            });
        }
        
        public static async Task ReplaceRandomKeepBest<TGene>(
            this GAFunctions ga,
            List<Chromosome<TGene>> parents,
            IEnumerable<Chromosome<TGene>> childs)
        {
            var count = parents.Count();

            await Task.Run(() =>
            {
                Random r = new Random();

                Chromosome<TGene> bestParent = parents.MaxBy(c => c.FF);
                Chromosome<TGene> bestchild = childs.MaxBy(c => c.FF);

                //parents[0] = bestchild.FF > bestParent.FF ? bestchild : bestParent;
                //parents[1] = bestchild.FF > bestParent.FF ? bestchild : bestParent;

                parents[0] = bestParent;
                parents[1] = bestchild;

                for (int k = 2; k < count; k++)
                {
                    if (r.NextDouble() > 0.5)
                        parents[k] = childs.ElementAt(k);
                }
            });
        }
    }
}
