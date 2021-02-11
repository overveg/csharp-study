using System;


namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();
            DateTime today = DateTime.Now;

            Console.WriteLine($"Привет, {name}, сегодня {today:d}");

        }
    }
}
