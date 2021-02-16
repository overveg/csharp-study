using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2_task4
{
    class Program
    {
        static void Main(string[] args)
        {

            //4. Для полного закрепления понимания простых типов найдите любой чек, либо фотографию этого чека в интернете и схематично нарисуйте его в консоли, только за место динамических, по вашему мнению, данных(это может быть дата, название магазина, сумма покупок) подставляйте переменные, которые были заранее заготовлены до вывода на консоль.

            string name = "Магазин SOLOMON";
            string inn = "133213568354";
            string title1 = "Фарш";
            double price1 = 170.50;
            double count1 = 1.275;
            decimal total1 = (decimal)price1 * (decimal)count1;

            Console.WriteLine($"МЕСТО РАСЧЕТОВ {name}");
            Console.WriteLine($"ИНН {inn}");
            Console.WriteLine($"");
            Console.WriteLine("КАССОВЫЙ ЧЕК");
            Console.WriteLine($"{title1}");
            Console.WriteLine($"{price1} х {count1} = {total1}");

        }
    }
}
