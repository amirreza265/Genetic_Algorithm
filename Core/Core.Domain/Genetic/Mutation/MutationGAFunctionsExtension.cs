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

        public static void BitMutation(this GAFunctions ga, Chromosome<bool> chromosome, int? position = null)
        {
            if (chromosome is null)
                position = new Random().Next(0, chromosome.Length);

            bool val = new Random().NextDouble() >= 0.5d;

            chromosome.Set((int)position, val);
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
