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

            if(!parent1.Length.Equals(parent2.Length))
            {
                throw new NonCongenericParentsException();
            }

            if (point is null)
            {
                point = new Random().Next(0,parent1.Length);
            }

            int cPoint = (int)point + 1;

            // set child 1
            child1.SetRange(parent1.GetSub(0, cPoint));
            child1.SetRange(parent2.GetSub(cPoint, child1.Length - cPoint), cPoint);

            // set child 2
            child2.SetRange(parent2.GetSub(0, cPoint));
            child2.SetRange(parent1.GetSub(cPoint, child2.Length - cPoint), cPoint);
        }

        // TODO : Add multiplePoint Crossover
    }
}
