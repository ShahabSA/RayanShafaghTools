using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Windows.Forms.Validation
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class RequiredAttribute : Attribute
    {
        public string GroupName { get; private set; }
        public string ErrorMessage { get; private set; }
        public ValidationLevel Level { get; private set; }
        public bool StickInControl { get; private set; }
        public string SubGroupName { get; set; }

        public RequiredAttribute(string groupName, string errorMessage = "", ValidationLevel level = ValidationLevel.FieldLevel, bool stickInControl = false)
        {
            this.GroupName = groupName;
            this.ErrorMessage = errorMessage;
            this.Level = level;
            this.StickInControl = stickInControl;

        }
    }
}
