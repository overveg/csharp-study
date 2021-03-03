using System;
using System.IO;

namespace Lesson5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
            Console.WriteLine("Введите строку:");
            string userInput = Console.ReadLine();

            string filename = "text.txt";
            File.WriteAllText(filename, userInput);
        }

    }
}
