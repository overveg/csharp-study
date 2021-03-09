using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6._4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*4.Создать класс "Сотрудник" с полями: ФИО, должность, email, телефон, зарплата, возраст;
            Конструктор класса должен заполнять эти поля при создании объекта;
            Внутри класса «Сотрудник» написать метод, который выводит информацию об объекте в консоль;
            Создать массив из 5 сотрудников
            Пример:
            Person[] persArray = new Person[5]; // Вначале объявляем массив объектов
            persArray[0] = new Person("Ivanov Ivan", "Engineer", "ivivan@mailbox.com", "892312312", 30000, 30); // потом для каждой ячейки массива задаем объект
            persArray[1] = new Person(...);
            ...
            persArray[4] = new Person(...);
            С помощью цикла вывести информацию только о сотрудниках старше 40 лет;*/

            Person[] persArray = new Person[5]; // Вначале объявляем массив объектов
            persArray[0] = new Person("Ivanov Ivan", "Engineer", "ivivan@mailbox.com", "+892312312", 30000, 30); // потом для каждой ячейки массива задаем объект
            persArray[1] = new Person("Petrov Petr", "Engineer", "pert@mailbox.com", "+792312312", 30000, 40);
            persArray[2] = new Person("Kostomarov Ivan", "Engineer", "kost@mailbox.com", "+692312312", 30000, 50);
            persArray[3] = new Person("Jenkins Ivan", "Engineer", "jen@mailbox.com", "+592312312", 30000, 60);
            persArray[4] = new Person("Rickman Rick", "Engineer", "rick@mailbox.com", "+15692312312", 30000, 70);

            Console.WriteLine("Сотрудники старше 40 лет:");
            int index = 0;
            foreach (var item in persArray)
            {
                if (item.Age > 40)
                {
                    Console.WriteLine($"{persArray[index].info()}");
                }
                index++;
            }

        }
    }
}
