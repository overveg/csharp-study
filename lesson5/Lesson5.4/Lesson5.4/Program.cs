using System;
using System.IO;

namespace Lesson5._4
{
    class Program
    {
        static void Main(string[] args)
        {
            string workDir = @"d:\Projects\viktoria\test\";
            string[] entries = Directory.GetFileSystemEntries(workDir, "*", SearchOption.AllDirectories);

            //с рекурсией
            Console.WriteLine("с рекурсией");
            GetCatalog(0, entries);
            

            //без рекурсии
            Console.WriteLine("без рекурсии");
            for (int i = 0; i < entries.Length; i++)
            {
                Console.WriteLine($">{new DirectoryInfo(entries[i]).Name}");
            }
            Console.WriteLine("");
            Console.WriteLine("");


            //с рекурсией с конца строки
            Console.WriteLine("с рекурсией с конца строки");
            GetCatalogAlter(entries.Length - 1, entries);
        }

       
        static string GetCatalog( int index, string[] array)
        {
            //с начала строки
            if (index < array.Length)
            {
                Console.WriteLine($">{new DirectoryInfo(array[index]).Name}");
                return GetCatalog(index + 1, array);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            return "";
        }
        static string GetCatalogAlter(int index, string[] array)
        {
            //с конца строки
            if (index >= 0)
            {
                Console.WriteLine($"{new DirectoryInfo(array[index]).Name}>");
                return GetCatalogAlter(index - 1, array);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            return "";
        }

    }
}
