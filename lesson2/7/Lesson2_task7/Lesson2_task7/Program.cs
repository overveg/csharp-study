using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_task7
{
    class Program
    {
        static void Main(string[] args)
        {
            //7. Написать программу, которая определяет является ли год високосным, и выводит сообщение в консоль.
            // Каждый 4-й год является високосным, кроме каждого 100-го, при этом каждый 400-й – високосный.

            int year = 2021;
            bool isLeap = (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
            Console.WriteLine(isLeap ? "високосный" : "не високосный");

        }
    }
}
