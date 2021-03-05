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
            public string Coord { get; }

            public MyArrayDataException(string coord)
            {
                Coord = coord;
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
            с детализацией в какой именно ячейке лежат неверные данные.
            В методе main() вызвать полученный метод, 
            обработать возможные исключения MySizeArrayException и MyArrayDataException,
            и вывести результат расчета.*/

            string[,] array = { { "1", "2", "3", "4" }, { "1", "2", "3", "4" }, { "1", "2", "3", "4" }, { "1", "2", "3", "4" } };
            //string[,] array = { { "1", "2", "3" }, { "1", "2", "3" }, { "1", "2", "3" } };

            try
            {
                Method(array);
            }
            catch (MyArraySizeException)
            {
                Console.WriteLine("MyArraySizeException");
            }
            catch (MyArrayDataException Ex)
            {
                Console.WriteLine($"Возникли ошибки: {Ex.Coord}");
            }
        }
        static void Method(string[,] array)
        {
            if (array.GetLength(0) != 4 || array.GetLength(1) != 4)
            {
                throw new MyArraySizeException();
            }
            int result = 0;
            string coord = "";
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    bool isNumber = int.TryParse(array[i, j], out int number);
                    if (!isNumber)
                    {
                        coord += $" в cтроке: {i + 1}, cтолбце {j + 1}, указано недопустимое зачение: {array[i, j]}; ";

                    }
                    else
                    {
                        result += number;
                    }

                }
            }
            if (coord !="") {
                throw new MyArrayDataException(coord);
            }
            else {
                Console.WriteLine($"Результат: {result}");
            }

        }
    }
}
