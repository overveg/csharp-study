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
            GetCatalog(entries.Length - 1, entries);
            Console.WriteLine("");

            //без рекурсии
            Console.WriteLine("без рекурсии");
            for (int i = 0; i < entries.Length; i++)
            {
                Console.Write($">{new DirectoryInfo(entries[i]).Name}");
            }
            Console.WriteLine("");
        }

        static string GetCatalog(int index, string[] array)
        {
            //с конца строки
            if (index >= 0)
            {
                Console.Write($"{new DirectoryInfo(array[index]).Name}>");
                return GetCatalog(index - 1, array);
            }

            return "";
        }
    }
}
