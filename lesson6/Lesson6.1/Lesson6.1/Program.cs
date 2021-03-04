using System;
using System.IO;


namespace Lesson6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.
            string workDir = @"d:\Projects\viktoria\test\";
            string[] entries = Directory.GetFileSystemEntries(workDir, "*", SearchOption.AllDirectories);


            Console.WriteLine($"с рекурсией");
            GetCatalog(0, entries);


            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}без рекурсии");
            for (int i = 0; i < entries.Length; i++)
            {
                string tab = new String(' ', i); 
                Console.WriteLine($"{tab}>{new DirectoryInfo(entries[i]).Name}");
            }

            //Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}с рекурсией с конца строки");
            //GetCatalogAlter(entries.Length - 1, entries);
        }


        static string GetCatalog(int index, string[] array)
        {
            //с начала строки
            if (index < array.Length)
            {
                string tab = new String(' ', index);
                Console.WriteLine($"{tab}>{new DirectoryInfo(array[index]).Name}");
                return GetCatalog(index + 1, array);
            }
           
            return "";
        }
        //static string GetCatalogAlter(int index, string[] array)
        //{
        //    //с конца строки
        //    if (index >= 0)
        //    {
        //        Console.WriteLine($"{new DirectoryInfo(array[index]).Name}>");
        //        return GetCatalogAlter(index - 1, array);
        //    }

        //    return "";
        //}
    }
}
