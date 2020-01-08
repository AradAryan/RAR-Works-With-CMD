using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmd
{
    class Program
    {
        public static string outputPath;
        public static bool type;
        public static string[] files;
        static void Main(string[] args)
        {
            files = new string[args.Length - 4];

            if (args.Length == 0)
            {
                Console.Write("Please Enter a Command");
            }
            else
            {
                var command = args[0];
                // Console.Write(command);
                int counter = 0;
                foreach (var item in args)
                {
                    if (item.ToLower() == "-out" )//&& args[counter + 1].StartsWith("\"") && args[counter + 1].EndsWith("\""))
                    {
                        outputPath = args[counter + 1];
                    }
                    //else
                    //{
                    //    Console.WriteLine("Wrong Value For output Address!");
                    //    break;
                    //}
                    if (item.ToLower() == "-format" && (args[counter + 1].ToLower() == "zip" || args[counter + 1].ToLower() == "rar"))
                    {
                        if (args[counter + 1].ToLower() == "zip")
                            type = true;

                        if (args[counter + 1].ToLower() == "rar")
                            type = false;
                    }
                    //else
                    //{
                    //    Console.WriteLine("Wrong Value For File Format, please choose [zip] or [rar]");
                    //    break;
                    //}
                    if (item.ToLower() == "-files")
                    {
                        for (int i = 1; i <= args.Length - 4; i++)
                        {
                            if (!(counter + i >= args.Length))
                            {
                                // if (args[counter + i].StartsWith("\"") && args[counter + i].EndsWith("\""))
                                // {
                                files[i - 1] = args[counter + 1];
                                // }
                            }
                            else
                            {
                                if (files.Length < 1)
                                {
                                    Console.WriteLine("Wrong Files Selected!");
                                    break;
                                }
                            }
                            
                        }

                    }
                    //else
                    //{
                    //    Console.WriteLine("Wrong Value For File Format, please choose [zip] or [rar]");
                    //    break;
                    //}
                    counter++;
                }

            }
            Console.WriteLine(outputPath);
            Console.WriteLine(type);
            foreach (var item in files)
            {
                Console.Write(item + ", ");
            }

            Console.ReadKey();
        }

    }
}
