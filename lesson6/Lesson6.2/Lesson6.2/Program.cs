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
            }
            else
            {
                Console.WriteLine("В списке нет задач.");
            }
            //сделать выбор - добавить новую задачу/отметить задачу выполненной
            MakeChoice();
            
        }

        static void MakeChoice() {

            Console.WriteLine("Добавить новую задачу - нажмите 1");
            Console.WriteLine("Отметить задачу выполненной - нажмите 2");
            int.TryParse(Console.ReadLine(), out int userChoice);
            switch (userChoice)
            {
                case 1:
                    //добавляем новую задачу
                    string choiceNew = "";
                    do
                    {
                        AddTask(GetNewTask());
                        Console.WriteLine("Добавить еще одну задачу? y/n");
                        choiceNew = Console.ReadLine();

                    } while (choiceNew == "y");

                    //выводим список задач
                    ShowTasks();
                    MakeChoice();
                    break;
                case 2:
                    CheckTasks();
                    MakeChoice();
                    break;
                default:
                    MakeChoice();
                    break;
            }
        }


        static void CheckTasks()
        {
            string choiceDone = "";
            do
            {
                //отмечаем выполненные задачи
                Console.WriteLine("Отметьте выполненные задачи. Укажите номер выполненной задачи:");
                string userTaskId = Console.ReadLine();

                ToDo[] tasksArray = ReadTasks();

                bool isNumber = int.TryParse(userTaskId, out int result);
                if (isNumber && result > 0 && result <= tasksArray.Length)
                {
                    CheckTaskDone(result-1);
                    ShowTasks();
                }
                else
                {
                    Console.WriteLine("Не удалось распознать номер задачи.");
                }
                Console.WriteLine("Указать еще одну задачу выполненной? y/n");
                choiceDone = Console.ReadLine();
            }
            while (choiceDone == "y");
        }
        /// <summary>
        /// Добавляет новый элемент в массив задач
        /// </summary>
        static void AddTask(ToDo task)
        {
            //проверяем есть ли файл tasks.json
            if (File.Exists(Path.Combine(workDir, filename)))
            {
                //создаем новый массив, куда записываем все старые задачи и новую
                ToDo[] OldTasks = ReadTasks();
                ToDo[] NewTasks = new ToDo[OldTasks.Length + 1];
                Array.Copy(OldTasks, NewTasks, OldTasks.Length);

                NewTasks[OldTasks.Length] = task;

                //сохраняем в файл
                SaveTasks(NewTasks);
            }
            else
            {
                ToDo[] NewTasks = new ToDo[1];
                NewTasks[0] = task;

                //сохраняем в файл
                SaveTasks(NewTasks);
            }
        }


        static ToDo GetNewTask()
        {
            Console.WriteLine($"{Environment.NewLine}Введите название новой задачи:");
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
            Console.WriteLine($"{Environment.NewLine}Список задач:");
            ToDo[] tasksArray = ReadTasks();

            int index = 1;
            foreach (var item in tasksArray)
            {
                System.Console.WriteLine($"{index} {(item.IsDone ? "[x] ":"[ ] ")}{item.Title}");
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

            tasksArray[taskId].IsDone = true;

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



    }
}
