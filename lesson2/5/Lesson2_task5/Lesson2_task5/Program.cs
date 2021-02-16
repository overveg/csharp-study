using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_task5
{
    class Program
    {
        static void Main(string[] args)
        {
            //5.  (*) Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».

            Console.Write("Введите порядковый номер текущего месяца: ");
            int monthInput = Convert.ToInt32(Console.ReadLine());
            if (monthInput == 1 || monthInput == 2 || monthInput == 12)
            {
                Console.Write("Введите минимальную температуру за сутки: ");
                string minTemp = Console.ReadLine();

                Console.Write("Введите максимальную температуру за сутки: ");
                string maxTemp = Console.ReadLine();

                if (Double.TryParse(minTemp.Replace('.', ','), out Double min) && Double.TryParse(maxTemp.Replace('.', ','), out Double max))
                {
                    Double midTemp = (min + max) / 2;
                    if (midTemp > 0)
                    {
                        Console.WriteLine("Дождливая зима");
                    }
                }
                else
                {
                    Console.Write("Не удалось обработать входные данные ");
                }
            }
        }
    }
}
