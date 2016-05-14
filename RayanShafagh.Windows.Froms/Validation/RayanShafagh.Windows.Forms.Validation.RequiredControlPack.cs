using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayanShafagh.Windows.Forms.Validation
{
    public class RequiredControlPack
    {
        public RequiredAttribute Attribute { get; private set; }
        public Control ControlObject { get; private set; }

        public RequiredControlPack(Control ControlObject, RequiredAttribute Attribute)
        {
            this.Attribute = Attribute;
            this.ControlObject = ControlObject;
        }
    }
}
