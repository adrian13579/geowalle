using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.GObjects
{
    public class Text : GObject
    {
        public string Content { get; }
        public Text(string content)
        {
            Content = content;
        }
        public override string GObjectType()
        {
            return "Text";
        }
        public override bool IsASequence()
        {
            return false ;
        }
    }
}
