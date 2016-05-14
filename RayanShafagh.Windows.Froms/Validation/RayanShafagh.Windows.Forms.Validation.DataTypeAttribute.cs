using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Windows.Forms.Validation
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DataTypeAttribute : Attribute
    {
        public DataType Type { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool StickInControl { get; private set; }

        public DataTypeAttribute(DataType type, string errorMessage, bool stickInControl = false)
        {
            this.Type = type;
            this.ErrorMessage = errorMessage;
            this.StickInControl = stickInControl;
        }
    }
}
