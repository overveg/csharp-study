using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //2.Написать программу «Телефонный справочник»: создать двумерный массив 5х2, хранящий список телефонных контактов: первый элемент хранит имя контакта, второй — номер телефона/ email.

            string[,] tel = {
            {"Егор", "e@mail.ru" },
            {"Руслан", "r@mail.ru" },
            {"Маша", "m@mail.ru" },
            {"Даша", "d@mail.ru" },
            {"Саша", "s@mail.ru" }
            };
            for (int i = 0; i < tel.GetLength(0); i++)
            {
                //выводим все поля 
                Console.Write($"{i}) ");
                for (int k = 0; k < tel.GetLength(1); k++)
                {
                    Console.Write($"{tel[i, k]} ");
                }

                //выводим по-другому
                //Console.Write($"{i}) {tel[i, 0]}  ({tel[i, 1]})");

                Console.WriteLine("");
            }

        }
    }
}
