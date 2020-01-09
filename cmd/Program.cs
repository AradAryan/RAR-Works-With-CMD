using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cmd
{
    class Program
    {
        #region Fields
        /// <summary>
        /// Output Directory of WinRAR
        /// </summary>
        public static string outputPath;

        /// <summary>
        /// File Format .zip or .rar
        /// </summary>
        public static bool type;

        /// <summary>
        /// Path of All Files 
        /// </summary>
        public static string files;
        #endregion

        #region Run Compress Command
        /// <summary>
        /// Run Compress Command For WinRAR.EXE
        /// </summary>
        static public void RunCommand()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "WinRAR.exe";
            startInfo.Arguments = $"a {outputPath} {files}";
            process.StartInfo = startInfo;
            process.Start();

            Console.Write("File Created at: ");
            Console.WriteLine(outputPath);
            Console.Write("Format: ");
            if (type)
                Console.WriteLine("zip");
            else
                Console.WriteLine("rar");
            Console.Write("Contains: ");
            Console.WriteLine(files);
        }
        #endregion

        #region Main
        /// <summary>
        /// Main Function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Write("Wrong Usage!");
            }
            else
            {
                var command = args[0];
                int counter = -1;

                foreach (var item in args)
                {
                    counter++;
                    switch (item.ToLower())
                    {
                        case "-out":
                            outputPath = $"{ args[counter + 1]}";
                            continue;

                        case "-format":
                            switch (args[counter + 1])
                            {
                                case "zip":
                                    type = true;
                                    break;

                                case "rar":
                                    type = false;
                                    break;
                            }
                            continue;

                        case "-files":
                            int temp = counter + 1;
                            for (int i = 0; i < args.Length - 4; i++)
                            {
                                if (!(temp >= args.Length))
                                {
                                    files += $"{args[temp]} ";
                                    temp++;
                                    continue;
                                }
                                break;
                            }
                            break;
                    }
                }
            }

            if (type)
                outputPath += ".zip";
            else
                outputPath += ".rar";

            RunCommand();

            Console.ReadKey();
        }
        #endregion
    }
}
