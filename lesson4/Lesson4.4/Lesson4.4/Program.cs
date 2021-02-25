using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            //4. (*) Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом.
            Console.WriteLine("Введите число");
            int element = Convert.ToInt32(Console.ReadLine());
            getFibonacci(element);
            Console.WriteLine(getFibonacci(element));
        }
        static int getFibonacci(int element)
        {
            return element <= 1 ? element : getFibonacci(element - 1) + getFibonacci(element - 2);
        }
    }
}
