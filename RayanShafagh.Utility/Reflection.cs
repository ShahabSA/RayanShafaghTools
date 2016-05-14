using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Utility
{
    public static class Reflection
    {
        public static string GetCurrentMethodName()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            return methodBase.Name;
        }

        public static string GetParentMethodName()
        {
            StackTrace stackTrace = new StackTrace();
            if (stackTrace.FrameCount >= 3)
            {
                StackFrame stackFrame = stackTrace.GetFrame(2);
                MethodBase methodBase = stackFrame.GetMethod();
                return methodBase.Name;
            }
            else
            {
                return null;
            }

        }

    }
}
