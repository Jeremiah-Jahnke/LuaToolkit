using System;
using System.IO;
using LuaToolkit.Core;
using LuaToolkit.Disassembler;
using LuaToolkit.Decompiler;

class test2
{
    static void Main(string[] args)
    {
        foreach (var path in args)
        {
            var luac = new LuaCFile(File.ReadAllBytes(path));
            var decoder = new LuaDecoder(luac);
            var decompiler = new LuaDecompiler(decoder);
            Console.WriteLine(decompiler.LuaScript);
        }
    }
}