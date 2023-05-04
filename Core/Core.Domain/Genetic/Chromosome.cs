

using System.Text;

namespace Core.Domain.Genetic
{
    public class Chromosome<TGene>
    {
        private int _length = 1;

        public int Id { get; private set; } 

        public Func<TGene[], double> FitnessFunction { get; set; }
        public Func<TGene[], double> ObjectiveFunction { get; set; }

        public double FF { get => GetFitnessValue(); }
        public double OF { get => GetObjectiveValue(); }

        public Chromosome(int length, int? id = null)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException("The length of the chromosome should be bigger than 0");
            }

            _length = length;

            Genes = new TGene[length];

            if (id == null)
                Id = new Random().Next();
            else
                Id = (int)id;
        }

        public TGene[] Genes { get; set; }

        public int Length { get => _length; }

        public TGene[] GetGenesCopy()
        {
            return Genes.Clone() as TGene[];
        }

        public TGene Get(int index)
        {
            return Genes[index];
        }

        public TGene[] GetSub(int start, int length)
        {
            if (start + length > _length)
            {
                throw new ArgumentOutOfRangeException("start + length is bigger than chromosome length");
            }

            TGene[] sub = new TGene[length];
            for (int i = 0; i< length; i++)
            {
                sub[i] = Get(i + start);
            }

            return sub;
        }

        public void SetRange(TGene[] sub, int start = 0)
        {
            if (start + sub.Length > _length)
            {
                throw new ArgumentOutOfRangeException("start + sub length is bigger than chromosome length");
            }

            for (int i = 0; i < sub.Length; i++)
            {
                Set(i + start, sub[i]);
            }
        }

        public void Set(int index, TGene value)
        {
            Genes[index] = value;
        }
        public void SetSub(TGene val, int start = 0, int count = 1)
        {
            if (start + count > _length)
            {
                throw new ArgumentOutOfRangeException("start + count is bigger than chromosome length");
            }

            for (int i = 0; i < count; i++)
            {
                Set(i + start, val);
            }
        }

        public double GetFitnessValue()
        {
            return FitnessFunction(Genes);
        }

        public double GetObjectiveValue()
        {
            return ObjectiveFunction(Genes);
        }

        public Chromosome<TGene> Copy()
        {
            var g = new Chromosome<TGene>(Length);
            g.Genes = GetGenesCopy();
            g.FitnessFunction = FitnessFunction;
            g.ObjectiveFunction = ObjectiveFunction;
            return g;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append($"{Id}:[");
            foreach (var gene in Genes)
            {
                str.Append($"{gene},");
            }
            str.Append("]");

            return str.ToString();
        }

        public static bool operator <(Chromosome<TGene> ch1, Chromosome<TGene> ch2)
        {
            return ch1.OF < ch2.OF;
        }
        public static bool operator >(Chromosome<TGene> ch1, Chromosome<TGene> ch2)
        {
            return ch1.OF > ch2.OF;
        }
    }
}
