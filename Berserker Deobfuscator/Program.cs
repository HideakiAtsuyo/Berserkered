using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Berserker_Deobfuscator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Obfuscated Python File Path: ");
            string file = Console.ReadLine().Replace("\"", string.Empty);
            Oof.FileExist(file);
            string Berserkered = Regex.Match(File.ReadAllText(file), "('''.*''')").ToString().Replace("'''", string.Empty);
            string code = Properties.Settings.Default.pythonScript.Replace("|content|", Berserkered);
            string output1 = String.Format("{0}Berserkered.py", Path.GetTempPath());
            File.WriteAllText(output1, code);
            Console.WriteLine("Specify your python.exe File Path: ");
            string PIP = Console.ReadLine().Replace("\"", string.Empty);
            Oof.FileExist(PIP);
            ProcessStartInfo proc = new ProcessStartInfo()
            {
                FileName = PIP,
                Arguments = output1,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                LoadUserProfile = true
            };
            Process process = Process.Start(proc);
            process.Start();
            process.WaitForExit();
            File.Delete(output1);
            using (StreamReader reader = process.StandardOutput)
            {
                string err = process.StandardError.ReadToEnd();
                if (err.Length > 0)
                {
                    Console.WriteLine(String.Format("Error:\n{0}", err));
                    Console.ReadLine();
                    Environment.Exit(1337);
                }
                Console.WriteLine("Oofed !");
                Console.ReadLine();
            }
        }
    }
}
