using dnlib.DotNet;

namespace SimpleObfuscator.ProtectSolution
{
    internal class Renamer : Randoms
    {
        public static void Execute(ModuleDefMD module)
        {
            foreach (TypeDef typeDef in module.Types)
            {
                bool flag = CanRename(typeDef);
                if (flag)
                {
                    typeDef.Name = RandomString();
                }
                foreach (MethodDef methodDef in typeDef.Methods)
                {
                    bool flag2 = CanRename(methodDef);
                    if (flag2)
                    {
                        methodDef.Name = RandomString();
                    }
                    foreach (Parameter parameter in methodDef.Parameters)
                    {
                        parameter.Name = RandomString();
                    }
                }
                foreach (PropertyDef propertyDef in typeDef.Properties)
                {
                    bool flag3 = CanRename(propertyDef);
                    if (flag3)
                    {
                        propertyDef.Name = RandomString();
                    }
                }
                foreach (FieldDef fieldDef in typeDef.Fields)
                {
                    bool flag4 = CanRename(fieldDef);
                    if (flag4)
                    {
                        fieldDef.Name = RandomString();
                    }
                }
            }
        }

        public static bool CanRename(object obj)
        {
            iAnalyze iAnalyze = null;
            bool flag = obj is TypeDef;
            if (flag)
            {
                iAnalyze = new TypeDefAnalyzer();
            }
            else
            {
                bool flag2 = obj is MethodDef;
                if (flag2)
                {
                    iAnalyze = new MethodDefAnalyzer();
                }
                else
                {
                    bool flag3 = obj is EventDef;
                    if (flag3)
                    {
                        iAnalyze = new EventDefAnalyzer();
                    }
                    else
                    {
                        bool flag4 = obj is FieldDef;
                        if (flag4)
                        {
                            iAnalyze = new FieldDefAnalyzer();
                        }
                    }
                }
            }
            bool flag5 = iAnalyze == null;
            return !flag5 && iAnalyze.Execute(obj);
        }
    }
}
