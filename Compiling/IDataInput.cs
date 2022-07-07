using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling
{
    public interface IDataInput
    {
        GObject CreateGObject(string gObjectType); 
    }
}
