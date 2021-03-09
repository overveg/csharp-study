using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6._3
{
    class Program
    {
        [Serializable]
        public class MyArraySizeException : Exception { }

        [Serializable]
        public class MyArrayDataException : Exception
        {
            public string Details { get; }

            public MyArrayDataException(string details)
            {
                Details = details;
            }
        }


        static void Main(string[] args)
        {
            /*3. 
            -Напишите метод, на вход которого подаётся двумерный строковый массив размером 4х4,
            -при подаче массива другого размера необходимо бросить исключение MyArraySizeException.
            -Далее метод должен пройтись по всем элементам массива, преобразовать в int, и просуммировать.
            -Если в каком-то элементе массива преобразование не удалось
            -(например, в ячейке лежит символ или текст вместо числа), 
            -должно быть брошено исключение MyArrayDataException, 
            -с детализацией в какой именно ячейке лежат неверные данные.
            -В методе main() вызвать полученный метод, 
            -обработать возможные исключения MySizeArrayException и MyArrayDataException,
            -и вывести результат расчета.*/

            string[,] array = { { "1", "2", "3", "4" }, { "1", "2", "3", "4" }, { "1", "2", "3", "4" }, { "1", "2", "3", "4" } };
            //string[,] array = { { "1", "2", "авп", "4" }, { "1", "кен", "3", "4" }, { "про", "2", "3", "4" }, { "1", "2", "3", "4" } };
            //string[,] array = { { "1", "2", "3" }, { "1", "2", "3" }, { "1", "2", "3" } };

            try
            {
                SumArray(array);
            }
            catch (MyArraySizeException)
            {
                Console.WriteLine("MyArraySizeException");
            }
            catch (MyArrayDataException Ex)
            {
                Console.WriteLine($"Возникли ошибки: {Environment.NewLine} {Ex.Details}");
            }
        }
        static void SumArray(string[,] array)
        {
            if (array.GetLength(0) != 4 || array.GetLength(1) != 4)
            {
                throw new MyArraySizeException();
            }
            int result = 0;
            string details = "";
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    bool isNumber = int.TryParse(array[i, j], out int number);
                    if (!isNumber)
                    {
                        details += $" в cтроке: {i + 1}, cтолбце {j + 1}, указано недопустимое зачение: {array[i, j]}{Environment.NewLine} ";
                    }
                    else
                    {
                        result += number;
                    }
                }
            }
            if (details != "")
            {
                throw new MyArrayDataException(details);
            }
            else
            {
                Console.WriteLine($"Результат: {result}");
            }
        }
    }
}
