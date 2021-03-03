using System;
using System.Text;
using System.IO;

namespace Lesson5._3
{
    class Program
    {
        static void Main(string[] args)
        {
            //3.Ввести с клавиатуры произвольный набор чисел(0...255) и записать их в бинарный файл.

            //ввод данных и запись в файл
            EnterNumbers();
            //дополнительно: вывод данных из бинарного файла в консоль
            ShowNumbers();
        }

        static void EnterNumbers() {

            Console.WriteLine("Введите набор чисел(0...255) через пробел:");
            string userInput = Console.ReadLine();

            //проверяем соблюдение условий ввода(0-255)
            if (CheckUserInput(userInput))
            {
                string[] stringArray = userInput.Split(' ');
                byte[] byteArray = new byte[stringArray.Length];
                for (int i = 0; i < stringArray.Length; i++)
                {
                    byteArray[i] = Byte.Parse(stringArray[i]);
                }
                saveToFile("binary.bin", byteArray);
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Введите числа от 0 до 255.");
                EnterNumbers();
            }
        }

        //проверяем что ввел пользователь
        static bool CheckUserInput(string userInput) {
            string[] input = userInput.Split(' ');

            foreach (var item in input)
            {
                bool isInt = Int32.TryParse(item, out int number);

                if (!isInt)
                {
                    return false;
                }
                else {
                    if (number < 0 || number > 255)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //записываем данные в файл
        static void saveToFile(string filename, byte[] input)
        {
            File.WriteAllBytes(filename, input);
        }

        //дополнительно: выводим данные из бинарного файла на консоль
        static void ShowNumbers() {
            byte[] ReadBytes = File.ReadAllBytes("binary.bin");
            string showBytes = "";
            foreach(var item in ReadBytes) {
                showBytes += Convert.ToInt32(item) + " ";
            }

             Console.WriteLine(showBytes);
        }
    }
}
