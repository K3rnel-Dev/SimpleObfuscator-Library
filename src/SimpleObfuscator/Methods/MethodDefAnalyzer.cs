using dnlib.DotNet;

namespace SimpleObfuscator.ProtectSolution
{
    public class MethodDefAnalyzer : iAnalyze
    {
        public override bool Execute(object context)
        {
            MethodDef methodDef = (MethodDef)context;
            bool isRuntimeSpecialName = methodDef.IsRuntimeSpecialName;
            bool result;
            if (isRuntimeSpecialName)
            {
                result = false;
            }
            else
            {
                bool isForwarder = methodDef.DeclaringType.IsForwarder;
                result = !isForwarder;
            }
            return result;
        }
    }
}
