using System;
using System.IO;

namespace Lesson5._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //2.Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
            string filename = "startup.txt";
            DateTime localDate = DateTime.Now;
            File.AppendAllText(filename, localDate.ToString("T"));
            File.AppendAllText(filename, Environment.NewLine);

        }
    }
}
