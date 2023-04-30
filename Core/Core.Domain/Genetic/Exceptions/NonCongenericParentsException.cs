using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Genetic.Exceptions
{
    public class NonCongenericParentsException : Exception
    {
        public NonCongenericParentsException() :
            base(message : "The selected parents are not of the same species and have different genes types")
        {
        }
    }
}
