using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Windows.Forms.Validation
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class RangeAttribute : Attribute
    {
        public int Min { get; private set; }
        public bool HasMin { get; set; }
        public int Max { get; private set; }
        public bool HasMax { get; set; }
        public string ErrorMessage { get; private set; }
        public bool StickInControl { get; private set; }

        public RangeAttribute(int min, int max, string errorMessage, bool stickInControl = false)
        {
            this.Max = max;
            this.Min = min;
            HasMin = true;
            HasMax = true;
            this.ErrorMessage = errorMessage;
            this.StickInControl = stickInControl;
        }

        public RangeAttribute(string errorMessage, int min, bool stickInControl = false)
        {
            this.Min = min;
            HasMin = true;
            HasMax = false;
            this.ErrorMessage = errorMessage;
            this.StickInControl = stickInControl;
        }

        public RangeAttribute(int max, string errorMessage, bool stickInControl = false)
        {
            this.Max = max;
            HasMax = true;
            HasMin = false;
            this.ErrorMessage = errorMessage;
            this.StickInControl = stickInControl;
        }

    }
}
