using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Genetic
{
    public sealed class GAFunctions
    {
        public GAFunctions()
        {
            
        }

        public static GAFunctions Instance { get; } = new GAFunctions();
    }
}
