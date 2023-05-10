using Core.Domain.Genetic.Crossover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Genetic.Repair
{
    public static class RepairGaFunctionsExtension
    {
        public static async Task<IEnumerable<Chromosome<TGene>>> RepairAsync<TGene>(this GAFunctions ga, IEnumerable<Chromosome<TGene>> chromosomes, Func<TGene[], TGene[]> repair)
        {
            int count = chromosomes.Count();
            List<Chromosome<TGene>> list = new List<Chromosome<TGene>>();

            if (count <= 1)
                return chromosomes;

            var random = new Random();
            await Task.Run(() =>
            {
                foreach (var ch in chromosomes)
                {
                    ch.SetRange(repair(ch.Genes));
                    list.Add(ch);
                }
            });

            return list;
        }
    }
}
