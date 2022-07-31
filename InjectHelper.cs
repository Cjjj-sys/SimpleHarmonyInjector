using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastWin32.Diagnostics;

namespace SimpleInjectorLib
{
    public class InjectHelper
    {
        //Injector
        public uint ProcessId { get; set; }
        public string AssemblyPath { get; set; }
        public string TypeName { get; set; }
        public string MethodName { get; set; }
        public string? Argument { get; set; }

        public bool TryInject()
        {
            if (AssemblyPath != null && TypeName != null && MethodName != null)
            {
                if (Argument != null)
                {
                    return Injector.InjectManaged(ProcessId, AssemblyPath, TypeName, MethodName, Argument);
                }
                else
                {
                    return Injector.InjectManaged(ProcessId, AssemblyPath, TypeName, MethodName, "");
                }
            }
            else
            {
                return false;
            }
        }
    }
}
