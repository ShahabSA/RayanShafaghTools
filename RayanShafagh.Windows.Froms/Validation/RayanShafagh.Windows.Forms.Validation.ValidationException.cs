using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Windows.Forms.Validation
{
    public class ValidationException:Exception
    {
        public ValidationException(string message)
        {
            this.message = message;
        }

        private string message;

        public override string Message
        {
            get
            {
                return message;
            }
        }

    }
}
