using System;
using System.IO;
using System.Text.Json;


namespace Lesson6._2
{

    class Program
    {
        public static string filename = "tasks.json";
        //берем путь к папке bin/Debug/
        public static string workDir = (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).Substring(6);

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




            //проверяем есть ли файл tasks.json
            if (File.Exists(Path.Combine(workDir, filename)))
            {
                //выводим список задач
                ShowTasks();

                //добавляем новую задачу
                AddTask(GetNewTask());

                //выводим список задач
                ShowTasks();

                //отмечаем выполненные задачи
                Console.WriteLine("Укажите номер выполненной задач:");
                int userTaskId = Convert.ToInt32(Console.ReadLine());
                CheckTaskDone(userTaskId);

                //выводим список задач
                ShowTasks();
            }
            else {
                //добавляем новую задачу
                AddTask(GetNewTask());
                //выводим список задач
                ShowTasks();
            }


        }

        static ToDo GetNewTask()
        {
            Console.WriteLine("Введите название новой задачи:");
            return new ToDo(Console.ReadLine(), false);
        }

        /// <summary>
        /// Десериализует список задач из файла
        /// </summary>
        static ToDo[] ReadTasks()
        {
            string jsonTodo = File.ReadAllText(filename);
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
            File.WriteAllText(filename, json);
        }

        /// <summary>
        /// Добавляет новый элемент в массив задач
        /// </summary>
        static void AddTask(ToDo task)
        {
            //проверяем есть ли файл tasks.json
            if (File.Exists(Path.Combine(workDir, filename)))
            {
                //создаем новый массив из старых задач и новой
                ToDo[] OldTasks = ReadTasks();
                ToDo[] NewTasks = new ToDo[OldTasks.Length + 1];

                int index = 0;
                foreach (var item in OldTasks)
                {
                    NewTasks[index] = OldTasks[index];
                    index++;
                }
                NewTasks[index] = task;
                SaveTasks(NewTasks);
            }
            else {
                ToDo[] NewTasks = new ToDo[1];
                NewTasks[0] = task;
                SaveTasks(NewTasks);
            }

        }

    }
}
