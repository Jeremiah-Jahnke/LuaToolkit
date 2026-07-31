using System;
using System.IO;
using LuaToolkit.Core;
using LuaToolkit.Disassembler;
using LuaToolkit.Decompiler;

namespace LuaToolkit.Cli
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Error.WriteLine("usuage: luadec <file.luac> [more.luac ...]");
                Console.Error.WriteLine("    decompiles compiled Lua 5.1 (.luac) back to source code.");
                return 1;
            }

            foreach(var path in args)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"[!] File not found: {path}");
                    continue;
                }

                var luac = new LuaCFile(File.ReadAllBytes(path));
                var decoder = new LuaDecoder(luac);
                var decompiler = new LuaDecompiler(decoder);
                Console.WriteLine(decompiler.LuaScript);
            }
            return 0;
        }
    }
}