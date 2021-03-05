using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Lesson6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*2. Список задач (ToDo-list):
-написать приложение для ввода списка задач;
-задачу описать классом ToDo с полями Title и IsDone;
-на старте, если есть файл tasks.json/xml/bin (выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;
-если задача выполнена, вывести перед её названием строку «[x]»;
-вывести порядковый номер для каждой задачи;
-при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
-записать актуальный массив задач в файл tasks.json/xml/bin.*/

            //берем путь к папке bin/Debug/
            string workDir = (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).Substring(6);

            //проверяем есть ли файл tasks.json
            if (File.Exists(Path.Combine(workDir, "tasks.json")))
            {
                ShowTasks();


                Console.WriteLine("Отметьте выполненные задачи - укажите номер:");
                int userTaskId = Convert.ToInt32(Console.ReadLine());

                CheckTaskDone(userTaskId);

                ShowTasks();
            }

        }

        /// <summary>
        /// Выводит в консоль список задач
        /// </summary>
        static ToDo[] ReadTasks()
        {

            string jsonTodo = File.ReadAllText("tasks.json");
            ToDo[] tasksArray = JsonSerializer.Deserialize<ToDo[]>(jsonTodo);
            return tasksArray;

        }


        /// <summary>
        /// Выводит в консоль список задач
        /// </summary>
        static void ShowTasks()
        {

            ToDo[] tasksArray = ReadTasks();

            int index = 1;
            foreach (var item in tasksArray)
            {
                string IsDoneFlag = "[ ] ";
                if (item.IsDone)
                {
                    IsDoneFlag = "[x] ";
                };
                System.Console.WriteLine($"{index} {IsDoneFlag}{item.Title}");
                index++;
            }

        }

        /// <summary>
        /// Устанавливает задаче значение - выполнена
        /// </summary>
        /// <param name="taskId">Номер задачи</param>
        static void CheckTaskDone(int taskId)
        {
            ToDo[] tasksArray = ReadTasks();

            tasksArray[taskId - 1].IsDone = true;

            SaveTasks(tasksArray);
        }

        /// <summary>
        /// Сохраняет данные в файл json
        /// </summary>
        static void SaveTasks(ToDo[] tasksArray)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(tasksArray, options);
            File.WriteAllText("tasks.json", json);
        }

    }
}
