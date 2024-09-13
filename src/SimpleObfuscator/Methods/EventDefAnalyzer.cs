using dnlib.DotNet;

namespace SimpleObfuscator.ProtectSolution
{
    public class EventDefAnalyzer : iAnalyze
    {
        public override bool Execute(object context)
        {
            EventDef eventDef = (EventDef)context;
            bool isRuntimeSpecialName = eventDef.IsRuntimeSpecialName;
            return !isRuntimeSpecialName;
        }
    }
}
