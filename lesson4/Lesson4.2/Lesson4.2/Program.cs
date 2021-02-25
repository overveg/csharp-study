using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //2.Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке. Ввести данные с клавиатуры и вывести результат на экран.
            Console.WriteLine("Введите набор чисел, разделенных пробелом:");
            string userInput = Console.ReadLine();
            string[] userArray = userInput.Split(' ');

            int result = 0;

            for (int j = 0; j < userArray.Length; j++)
            {
                bool isInteger = Int32.TryParse(userArray[j], out int number);
                if (isInteger)
                {
                    result += Convert.ToInt32(number);
                }
            }
            Console.WriteLine(result);
        }
    }
}
