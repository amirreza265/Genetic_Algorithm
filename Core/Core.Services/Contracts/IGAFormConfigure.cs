using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Contracts
{
    public interface IGAFormConfigure
    {
        void SetValues(int pm = 5, int pc = 95, int plotScale = 800);
    }
}
