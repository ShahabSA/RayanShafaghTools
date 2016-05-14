using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Windows.Forms.Validation
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class DefaultAttribute  : Attribute
    {
        
        public object Value { get; private set; }
        public Type DataType { get; private set; }

        public string TargetPropertyName { get; private set; }

        public DefaultAttribute(object value,Type dataType,string targetPropertyName)
        {
            this.Value = value;
            this.DataType = dataType;
            this.TargetPropertyName = targetPropertyName;
        }
    }
}
