using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2_task3
{
    class Program
    {
        static void Main(string[] args)
        {

            //3.Определить, является ли введённое пользователем число чётным.
            Console.Write("Введите любое число:");
            
            int input = Convert.ToInt32(Console.ReadLine());
           
            Console.WriteLine(input % 2 == 0 ? "Четное" : "Нечетное");

        }
    }
}
