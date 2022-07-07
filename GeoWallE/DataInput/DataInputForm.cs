using Compiling;
using Syncfusion.Windows.Forms.Edit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compiling.Parsing;
using Compiling.AST;
using Compiling.GObjects;

namespace GeoWallE.DataInput
{
    public class DataInputForm : IDataInput
    {
        Dictionary<string, IMiniDataInput> gObjectsForms = new Dictionary<string, IMiniDataInput>();

        public void RegisterFormForType(string type,IMiniDataInput form )
        {
            gObjectsForms.Add(type, form);
        }
        public GObject CreateGObject(string gObjectType)
        {
            throw new NotImplementedException();
        }
        private IMiniDataInput GetGobjectForm(string gObjectType)
        {
            IMiniDataInput form;
            if(gObjectsForms.TryGetValue(gObjectType,out form))
            {
                return form;
            }
            return null;
        }
    }
}
