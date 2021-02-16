using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_task6
{
    class Program
    {
        static void Main(string[] args)
        {
            //задача 6 Для полного закрепления битовых масок, попытайтесь создать универсальную структуру расписания недели, к примеру, чтобы описать работу какого либо офиса. Явный пример - офис номер 1 работает со вторника до пятницы, офис номер 2 работает с понедельника до воскресенья и выведите его на экран консоли.

            int officeSchedule = 0b0010011;
            //int office2 = 0b0011111;
            //int office3 = 0b0010011;
            //int office4 = 0b1100000;

            int mondayMask = 0b0000001;
            int tuesdayMask = 0b0000010;
            int wednesdayMask = 0b0000100;
            int thursdayMask = 0b0001000;
            int fridayMask = 0b0010000;
            int saturdayMask = 0b0100000;
            int sundayMask = 0b1000000;

            int isMonday = officeSchedule & mondayMask;
            int isTuesday = officeSchedule & tuesdayMask;
            int isWednesday = officeSchedule & wednesdayMask;
            int isThursday = officeSchedule & thursdayMask;
            int isFriday = officeSchedule & fridayMask;
            int isSaturday = officeSchedule & saturdayMask;
            int isSunday = officeSchedule & sundayMask;

            string result = "Дни работы офиса: "
            + ((isMonday == mondayMask) ? "пн " : "")
            + ((isTuesday == tuesdayMask) ? "вт " : "")
            + ((isWednesday == wednesdayMask) ? "ср " : "")
            + ((isThursday == thursdayMask) ? "чт " : "")
            + ((isFriday == fridayMask) ? "пт " : "")
            + ((isSaturday == saturdayMask) ? "сб " : "")
            + ((isSunday == sundayMask) ? "вс" : "");

            Console.WriteLine(result);

        }
    }
}
