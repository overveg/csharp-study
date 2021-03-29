using System;
using System.IO;
using System.Collections;
using Microsoft.VisualBasic;
using System.Text;

namespace Lesson9
{

    class Program
    {
        static string result = "";

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WindowWidth = 100;
            Console.WriteLine(Repeat("-", Console.WindowWidth));

            Console.Write("> ");
            Console.BackgroundColor = ConsoleColor.Black;

            string[] userInput = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            ReadCommand(userInput);
        }
       

        static void ReadCommand(string[] userInput)
        {

            switch (userInput[0])
            {
                case "ls":
                    //ls C:\Source -p 2
                    ShowCatalog(userInput[1]);
                    break;
                case "cp":
                    //cp C:\Source D:\Target
                    string source = userInput[1];
                    string target = userInput[2];
                    bool copySubDirs = true;
                    bool overwrite = true;

                    //проверяем что копируем - файлы или папки
                    if (Directory.Exists(source))
                    {
                        CopyDirectory(source, target, copySubDirs);
                    }
                    else if (File.Exists(source))
                    {
                        CopyFile(source, target, overwrite);
                    }
                    else
                    {
                        throw new DirectoryNotFoundException("Source directory or file does not exist or could not be found: " + source);
                    }
                    break;
                case "rm":
                    string targetToRemove = userInput[1];
                    RemoveDirectory(targetToRemove);
                    RemoveFile(targetToRemove);
                    break;
                case "file":
                    string filepath = userInput[1];
                    ShowInfo(filepath);

                    break;
                default:
                    //throw new Exception; 
                    break;
            }
        }


        static void ShowCatalog(string dir)
        {
            //без слеша в конце пути
            //string workDir = @"d:\Projects\viktoria\test";

            //выводим все папки и файлы из этой директории
            string[] entries = Directory.GetFileSystemEntries(dir, "*", SearchOption.AllDirectories);

            //сортируем
            Array.Sort(entries);

            //узнаем количество папок в исходном пути (чтобы потом вычислить уровень вложенности)
            string[] baseFolder = dir.Split(Path.DirectorySeparatorChar);
            int baseFolderCount = baseFolder.Length;

            //вывод в цикле
            GetCatalogWithFor(entries, baseFolderCount);
        }


        private static void CopyDirectory(string sourceDirName, string destDirName, bool copySubDirs)
        {
            //cp d:\Projects\viktoria\test\test3\ d:\Projects\viktoria\test\test7\
            // Берем подпапки
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            // Если папка не существует, создаем её
            DirectoryInfo targetDir = new DirectoryInfo(destDirName);
            if (!targetDir.Exists)
            {
                Directory.CreateDirectory(destDirName);
            }

            // Взять файлы и скопировать их в новую папку
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    CopyDirectory(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }
        static void CopyFile(string source, string target, bool overwrite)
        {
            //cp C:\source.txt D:\target.txt
            //cp d:\Projects\viktoria\test\test3\source.css d:\Projects\viktoria\test\test5\target.css
            string path = $@"{source}";
            string path2 = $@"{target}";
            FileInfo fi1 = new FileInfo(path);
            FileInfo fi2 = new FileInfo(path2);

            try
            {
                // Create the source file.
                //using (FileStream fs = fi1.Create()) { }

                //Ensure that the target file does not exist.
                if (File.Exists(path2) && overwrite)
                {
                    fi2.Delete();
                }
                else if (File.Exists(path2) && !overwrite)
                {
                    Console.WriteLine("Файл {target} уже существует");
                }

                //Copy the file.f
                fi1.CopyTo(path2);
                Console.WriteLine($"Файл {path} был скопирован в {path2}.");
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
        }
        static void RemoveDirectory(string dir)
        {
            try
            {
                if (Directory.Exists(dir))
                {
                    Directory.Delete(dir, true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка {e.Message}");
            }
        }
        static void RemoveFile(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка {e.Message}");
            }

        }
        static void ShowInfo(string filepath)
        {
            FileInfo fileInf = new FileInfo(filepath);
            if (fileInf.Exists)
            {
                Console.WriteLine($"Имя: {fileInf.Name} {fileInf.Extension} {fileInf.Length} {fileInf.LastWriteTime}");
            }
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
                //result += $"{tab}{new DirectoryInfo(array[i]).Name}{Environment.NewLine}";

                //выводим название папки с отступом
                if (level <= 2)
                {
                    Console.WriteLine($"{tab}{new DirectoryInfo(array[i]).Name}");
                }
            }
            result += Environment.NewLine;

        }

        static string Repeat(string s, int n)
        {
            return new StringBuilder(s.Length * n)
                            .AppendJoin(s, new string[n + 1])
                            .ToString();
        }

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

    }
}