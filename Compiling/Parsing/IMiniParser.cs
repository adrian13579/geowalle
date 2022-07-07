using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.Parsing
{
    public interface IMiniParser
    {
        void SelfRegister(Parser parser);
    }
}
