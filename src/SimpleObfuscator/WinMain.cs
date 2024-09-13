using dnlib.DotNet;
using SimpleObfuscator.ProtectSolution;
using System;

namespace SimpleObfuscator
{
    public class Obfuscator
    {
        public static string Save(byte[] Stub, string Path) // Stub = your.exe | Path = path to save your obfuscated file
        {
            string result;
            try
            {
                ModuleDefMD module = ModuleDefMD.Load(Stub); // .exe to obfuscate
                Execute(module); // Apply obfuscation methods
                module.Write(Path); // Saving obfuscated file
                result = "Success!"; // Return message
            }
            catch (Exception ex) // catch errors
            {
                result = ex.Message;
            }
            return result; // return result
        }

        private static void Execute(ModuleDefMD module)
        {
            Renamer.Execute(module);
            RandomOutlinedMethods.Execute(module);
        }
    }
}
