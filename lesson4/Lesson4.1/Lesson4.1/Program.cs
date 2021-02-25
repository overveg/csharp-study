using System;

namespace Lesson4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Написать метод GetFullName(string firstName, string lastName, string patronymic), принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО.Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.

            //getFullName("Иван", "Иванович", "Иванов");

            string[,] dictionary = {
            { "Иван","Иванович","Иванов" },
            { "Поликарп","Поликарпович","Поликарпов" },
            { "Руслан","Русланович","Русланов" }
            };
            for (int i = 0; i < dictionary.GetLength(0); i++)
            {
                getFullName(dictionary[i, 0], dictionary[i, 1], dictionary[i, 2]);
            }

        }

        static void getFullName(string firstName, string patronymic, string lastName)
        {
            Console.WriteLine($"{firstName} {patronymic} {lastName}");
        }

    }
}
