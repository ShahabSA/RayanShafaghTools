using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Windows.Forms.Validation
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DefaultValueModeAttribute : Attribute
    {
        public DefaultValueMode Mode { get; private set; }

        public DefaultValueModeAttribute(DefaultValueMode mode)
        {
            this.Mode = mode;
        }
    }
}
