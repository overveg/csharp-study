using System;

namespace Lesson3._1
{
    class Program
    {

        static void Main(string[] args)
        {
            //1.Написать программу, выводящую элементы двумерного массива по диагонали.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == i)
                    {
                        Console.Write("1");
                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
                Console.WriteLine("");
            }

        }
    }
}
