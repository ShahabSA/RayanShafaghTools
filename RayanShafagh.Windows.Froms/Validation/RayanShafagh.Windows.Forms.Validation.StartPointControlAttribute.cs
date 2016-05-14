using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayanShafagh.Windows.Forms.Validation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class StartPointControlAttribute:Attribute
    {
        public Control StartPoint { get; private set; }
    }
}
