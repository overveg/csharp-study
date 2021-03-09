using System;
using System.IO;
using System.Collections;

namespace Lesson6._1
{

    class Program
    {
        static string result = "";
        static void Main(string[] args)
        {

            //1. Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.

            //без слеша в конце пути
            string workDir = @"d:\Projects\viktoria\test";
            //выводим все папки и файлы из этой директории
            string[] entries = Directory.GetFileSystemEntries(workDir, "*", SearchOption.AllDirectories);

            //сортируем
            Array.Sort(entries);

            //выводим записи
            DisplayValues(entries);

            //узнаем количество папок в исходном пути (чтобы потом вычислить уровень вложенности)
            string[] baseFolder = workDir.Split(Path.DirectorySeparatorChar);
            int baseFolderCount = baseFolder.Length;

            result += "с рекурсией" + Environment.NewLine;
            GetCatalogWithRecursion(0, entries, baseFolderCount);

            result += "в цикле" + Environment.NewLine;
            GetCatalogWithFor(entries, baseFolderCount);

            //записываем в файл
            string filename = "tree.txt";
            File.WriteAllText(filename, result);
        }

        //выводит в консоль элементы массива
        public static void DisplayValues(string[] arr)
        {
            for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0); i++)
            {
                result += $"[{i}] : {arr[i]} {Environment.NewLine}";
                Console.WriteLine($"[{i}] : {arr[i]}");
            }
            result += Environment.NewLine;
            Console.WriteLine();
        }
        //рекурсия
        static string GetCatalogWithRecursion(int index, string[] array, int baseFolderCount)
        {
            if (index < array.Length)
            {
                //считаем количество директорий
                string mypath = array[index];
                string[] directories = mypath.Split(Path.DirectorySeparatorChar);
                int level = directories.Length - baseFolderCount;

                //выводим иерархический отступ
                string tab = new String('-', level);

                //записываем в файл
                result += $"{tab}{new DirectoryInfo(array[index]).Name}{Environment.NewLine}";

                //выводим название папки с отступом
                Console.WriteLine($"{tab}{new DirectoryInfo(array[index]).Name}");

                return GetCatalogWithRecursion(index + 1, array, baseFolderCount);
            }
            result += Environment.NewLine;
            Console.WriteLine();
            Console.WriteLine();
            return "";
        }

        //цикл
        static void GetCatalogWithFor(string[] array, int baseFolderCount)
        {
            for (int i = 0; i < array.Length; i++)
            {
                //считаем количество директорий
                string mypath = array[i];
                string[] directories = mypath.Split(Path.DirectorySeparatorChar);
                int level = directories.Length - baseFolderCount;

                //выводим иерархический отступ
                string tab = new String('-', level);

                //записываем в файл
                result += $"{tab}{new DirectoryInfo(array[i]).Name}{Environment.NewLine}";

                //выводим название папки с отступом
                Console.WriteLine($"{tab}{new DirectoryInfo(array[i]).Name}");
            }
            result += Environment.NewLine;
           
        }

        
    }
}
