using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            //3.Написать метод по определению времени года.
            //На вход подаётся число – порядковый номер месяца. На выходе — значение из перечисления(enum) — Winter, Spring, Summer, Autumn. 
            //Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года(зима, весна, лето, осень).
            //Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года. Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
            do {
                Console.WriteLine("Введите порядковый номер месяца:");
                bool success = Int32.TryParse(Console.ReadLine(), out int monthNumber) && monthNumber > 0 && monthNumber <= 12;
                if (success)
                {
                    Season currentSeason;
                    GetSeason(monthNumber, out currentSeason);
                    ShowSeason(currentSeason);
                }
                else
                {
                    Console.WriteLine("Ошибка: введите число от 1 до 12");
                }
            } while (true);
        }

        enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }
        static void GetSeason(int month, out Season currentSeason) {
            switch (month)
            {
                case 3:
                case 4:
                case 5:
                    currentSeason = Season.Spring;
                    break;
                case 6:
                case 7:
                case 8:
                    currentSeason = Season.Summer;
                    break;
                case 9:
                case 10:
                case 11:
                    currentSeason = Season.Autumn;
                    break;
                default:
                    currentSeason = Season.Winter;
                    break;
            }
        }
        static void ShowSeason(Season s)
        {
            switch (s)
            {
                case Season.Winter:
                    Console.WriteLine("зима");
                    break;
                case Season.Spring:
                    Console.WriteLine("весна");
                    break;
                case Season.Summer:
                    Console.WriteLine("лето");
                    break;
                case Season.Autumn:
                    Console.WriteLine("осень");
                    break;
            }
        }

    }
}
