using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Запросить у пользователя минимальную и максимальную температуру за сутки и вывести среднесуточную температуру.
            Console.Write("Введите минимальную температуру за сутки: ");
            string minTemp = Console.ReadLine();

            Console.Write("Введите максимальную температуру за сутки: ");
            string maxTemp = Console.ReadLine();

            if (Double.TryParse(minTemp.Replace('.', ','), out Double min) && Double.TryParse(maxTemp.Replace('.', ','), out Double max))
            {
                Double midTemp = (min + max) / 2;
                Console.Write($"Средняя температура: {midTemp} ");
            }
            else
            {
                Console.Write("Не удалось обработать входные данные ");
            }


        }
    }
}
