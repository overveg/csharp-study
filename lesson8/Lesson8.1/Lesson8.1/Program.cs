using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace Lesson8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*1. Написать консольное приложение Task Manager, которое 
             *- выводит на экран запущенные процессы и 
             * позволяет завершить указанный процесс. 
             * Предусмотреть возможность завершения процессов с помощью указания его ID или имени процесса. 
             * В качестве примера можно использовать консольные утилиты Windows tasklist и taskkill.*/

            var table = new Table();

            table.SetHeaders("ID", "ProcessName");

            foreach (Process process in Process.GetProcesses())
            {
                // выводим id и имя процесса
                table.AddRow(process.Id.ToString(), process.ProcessName);
                //Console.WriteLine($"{process.Id.ToString()} {process.ProcessName} {process.VirtualMemorySize64.ToString()}");
            }

            Console.WriteLine(table.ToString());
            Console.WriteLine($"Total: {Process.GetProcesses().Length} processes");

            Closing();
        }

        static void Closing()
        {
            //getting id
            Console.WriteLine(Environment.NewLine + "Введите ID процесса, который хотите завершить:");

            bool isNumber = Int32.TryParse(Console.ReadLine(), out int id);
            if (isNumber)
            {
                //selected process info
                try
                {
                    Process selectedProcess = Process.GetProcessById(id);

                    Console.WriteLine("Вы выбрали процесс " + selectedProcess.ProcessName);

                    Console.WriteLine("Завершить процесс? y/n");
                    string choice = Console.ReadLine();
                    if (choice == "y")
                    {
                        Exit(selectedProcess);
                    }
                    else
                    {
                        Closing();
                    }

                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Произошла ошибка: Процесс с id {id} не запущен");
                    Closing();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Произошла ошибка: {e.Message}");
                    Closing();
                }
            }
            else
            {
                Closing();
            }
        }

        static void Exit(Process proc)
        {
            /*CloseMainWindow enables an orderly termination of the process and closes all windows, so it is preferable for applications with an interface. If CloseMainWindow fails, you can use Kill to terminate the process. Kill is the only way to terminate processes that do not have graphical interfaces.*/
            try
            {
                //если приложение имеет графический интерфейс, закрываем мягко 
                if (proc.MainWindowHandle != IntPtr.Zero)
                {
                    // Close process by sending a close message to its main window.
                    proc.CloseMainWindow();
                    // Free resources associated with process.
                    proc.Close();
                    Console.WriteLine("Процесс завершен с помощью CloseMainWindow");
                }
                else
                {
                    proc.Kill();
                    proc.WaitForExit();
                    Console.WriteLine("Процесс завершен с помощью Kill");
                }
            }
            catch (Exception e) when (e is Win32Exception || e is FileNotFoundException)
            {
                Console.WriteLine($"Произошла ошибка: {e.Message}");
            }
        }

    }
}