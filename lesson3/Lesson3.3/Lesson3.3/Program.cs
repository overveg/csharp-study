using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            //3.Написать программу, выводящую введённую пользователем строку в обратном порядке(olleH вместо Hello).
            Console.WriteLine("Введите любое слово:");
            string input = Convert.ToString(Console.ReadLine());

            char[] inverted = input.ToCharArray();
            string result = "";
            for (int i = inverted.Length - 1; i >= 0; i--)
            {
                result += inverted[i];
            }
            Console.WriteLine(result);

        }
    }
}
