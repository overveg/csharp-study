using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача со звездочкой");
            //*«Морской бой»: вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.
            int[,] array = {
                { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 1, 0, 0, 1, 1, 0, 1, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0 }
            };
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 1)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write("O");
                    }

                }
                Console.WriteLine("");
               
            }
            Console.WriteLine("");

            //4.доп.ДЗ Написать программу, которой на вход подается одномерный массив и число n(может быть положительным, или отрицательным), при этом программа должна сместить все элементы массива на n позиций. Для усложнения задачи нельзя пользоваться вспомогательными массивами.

            Console.WriteLine("Задача 4. Введите массив (строку):");
            string userArray = Console.ReadLine();
            char[] arr = userArray.ToCharArray();

            Console.WriteLine("На какое количество символов нужно сместить элементы массива?");
            int userNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Length="+arr.Length);
            if (userNumber > 0) {
                //сдвигаем вправо
                for (var i = arr.Length - 1; i >= 0; i--)
                {
                    if (i + userNumber < arr.Length)
                    {
                        arr[i + userNumber] = arr[i];
                    }
                    arr[i] = '-';
                }
            }
            else if (userNumber < 0) {
                //сдвигаем влево
                for (var i = 0; i < arr.Length; i++)
                {
                    if (i + userNumber > -1)
                    {
                        arr[i + userNumber] = arr[i];
                     }
                    arr[i] = '-';
                }
            }

            for (var j = 0; j < arr.Length; j++)
            {
                Console.Write(arr[j]);
            }
        }
    }
}
