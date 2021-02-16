using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_task2
{
    class Program
    {
        static void Main(string[] args)
        {


            //2.Запросить у пользователя порядковый номер текущего месяца и вывести его название.
            string[] months = new string[] { "январь", "февраль", "март", "апрель", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь" };

            Console.Write("Введите порядковый номер текущего месяца: ");
            int monthInput = Convert.ToInt32(Console.ReadLine());

            if (monthInput != 0 && monthInput <= 12)
            {
                string result = months[monthInput - 1];
                Console.WriteLine($"Текущий месяц {result}");
            }
            else
            {
                Console.WriteLine("Неправильно введен порядковый номер месяца");
            }

        }
    }
}
