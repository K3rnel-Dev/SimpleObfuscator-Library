using dnlib.DotNet;

namespace SimpleObfuscator.ProtectSolution
{
    public class TypeDefAnalyzer : iAnalyze
    {
        public override bool Execute(object context)
        {
            TypeDef typeDef = (TypeDef)context;
            bool isRuntimeSpecialName = typeDef.IsRuntimeSpecialName;
            bool result;
            if (isRuntimeSpecialName)
            {
                result = false;
            }
            else
            {
                bool isGlobalModuleType = typeDef.IsGlobalModuleType;
                result = !isGlobalModuleType;
            }
            return result;
        }
    }
}
