using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6._4
{
    public class Person
    {
        /*.Создать класс "Сотрудник" с полями: ФИО, должность, email, телефон, зарплата, возраст;
            Конструктор класса должен заполнять эти поля при создании объекта;
            Внутри класса «Сотрудник» написать метод, который выводит информацию об объекте в консоль;
            Создать массив из 5 сотрудников*/

        public string FIO { get; }
        public string Position { get; }
        public string Email { get; }
        public string Tel { get; }
        public int Salary { get; }
        public int Age { get; }


        public Person(string fio, string position, string email, string tel, int salary, int age) {
            FIO = fio;
            Position = position;
            Email = email;
            Tel = tel;
            Salary = salary;
            Age = age;
        }

        public string info() {
            return $"{FIO} {Position} {Email} {Tel} {Salary} {Age}";
        }
    }
}
