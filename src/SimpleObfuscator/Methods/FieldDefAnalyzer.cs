using dnlib.DotNet;

namespace SimpleObfuscator.ProtectSolution
{
    public class FieldDefAnalyzer : iAnalyze
    {
        public override bool Execute(object context)
        {
            FieldDef fieldDef = (FieldDef)context;
            bool isRuntimeSpecialName = fieldDef.IsRuntimeSpecialName;
            bool result;
            if (isRuntimeSpecialName)
            {
                result = false;
            }
            else
            {
                bool flag = fieldDef.IsLiteral && fieldDef.DeclaringType.IsEnum;
                result = !flag;
            }
            return result;
        }
    }
}
