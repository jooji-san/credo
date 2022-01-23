using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("saidan gadagaqvs");
            string saidan = Console.ReadLine();
            Console.WriteLine("romel tarigze magalitad:19/6/2015 10:35:50 AM");
            string dro = Console.ReadLine();
            Console.WriteLine("sad");
            string sad = Console.ReadLine();

            DateTime shemosulidro = DateTime.Parse(dro);
            Console.WriteLine(shemosulidro);

            if (Directory.GetFiles(@$"{saidan}").Length > 0)
            {
                string[] files = Directory.GetFiles(@$"{saidan}");
                var gadatanilebi = new List<string>();
                foreach (var item in files)
                {

                    DateTime fileshecvla = File.GetLastWriteTime(item);

                    if (shemosulidro < fileshecvla)
                    {

                        File.Move(item, @$"{sad}\{Path.GetFileName(item)}");
                        gadatanilebi.Add(Path.GetFileName(item));
                    }
                    else
                    {
                        Console.WriteLine("am tarigis mere araferi shecvlila");
                    }
                }
                foreach (var filesmoved in gadatanilebi)
                {
                    Console.WriteLine($"gadatanilebi {filesmoved}");
                }
                Console.Read();
            }
            else
            {
                Console.WriteLine("folderi carielia");
            }
        }
    }
}
