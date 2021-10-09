using System;
using System.IO;

namespace Berserker_Deobfuscator
{
    public static class Oof
    {
        public static void FileExist(string x)
        {
            if (!File.Exists(x))
            {
                Console.WriteLine("This File Doesn't Exist !");
                Console.ReadLine();
                Environment.Exit(1337); // flushed lmaoooooooooooooooooooo
            }
        }
    }
}
