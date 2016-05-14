using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayanShafagh.Windows.Forms.Validation
{
    public class ControlCompletePack
    {
        public RequiredAttribute Required { get; private set; }
        public RangeAttribute Range { get; private set; }
        public DataTypeAttribute DataType { get; private set; }
        public StartPointControlAttribute StartPoint { get; private set; }

        public Control ControlObject { get; private set; }

        public ControlCompletePack(Control ControlObject, RequiredAttribute Required, 
                                   RangeAttribute Range, DataTypeAttribute DataType, 
                                   StartPointControlAttribute StartPoint)
        {
            this.Required = Required;
            this.Range = Range;
            this.DataType = DataType;
            this.StartPoint = StartPoint;
            this.ControlObject = ControlObject;
        }
    }
}
