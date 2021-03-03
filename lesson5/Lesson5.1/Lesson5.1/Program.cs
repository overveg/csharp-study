using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

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
