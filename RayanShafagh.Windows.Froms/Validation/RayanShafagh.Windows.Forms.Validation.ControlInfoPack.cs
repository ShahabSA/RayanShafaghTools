using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayanShafagh.Windows.Forms.Validation
{
    public class ControlInfoPack
    {
        public FieldInfo ControlFieldInfo { get; private set; }
        public Control ControlObject { get; private set; }
        //public IEnumerable<CustomAttributeData> CustomAttribute { get; private set; }

        public ControlInfoPack(Control ControlObject,FieldInfo ControlFieldInfo)//,IEnumerable<CustomAttributeData> CustomAttribute)
        {
            this.ControlFieldInfo = ControlFieldInfo;
            this.ControlObject = ControlObject;
            //this.CustomAttribute = CustomAttribute;
        }

    }
}
