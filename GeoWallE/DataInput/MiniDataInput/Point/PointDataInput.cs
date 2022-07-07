using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling;
using Compiling.GObjects;

namespace GeoWallE.DataInput
{
    public class PointDataInput : IMiniDataInput
    {
        public GObject GetObjectData()
        {
            throw new Exception();
        } 
        public void SelfRegister(DataInputForm dataInput)
        {
            dataInput.RegisterFormForType("Point", this);
        }
    }
}
