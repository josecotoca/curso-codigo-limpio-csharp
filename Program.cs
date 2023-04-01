using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuOption = 0;
            do
            {
                menuOption = ShowMainMenu();
                if ((Menu)menuOption == Menu.AddTask)
                {
                    ShowTaskAdd();
                }
                else if ((Menu)menuOption == Menu.RemoveTask)
                {
                    ShowTaskRemove();
                }
                else if ((Menu)menuOption == Menu.ListTask)
                {
                    ShowTaskList();
                }
            } while ((Menu)menuOption != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void ShowTaskRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                getTaskList();

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;
                if (indexToRemove > -1)
                {
                    if (TaskList.Count > 0)
                    {
                        string task = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowTaskAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                getTaskList();
            }
        }

        public static void getTaskList()
        {
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < TaskList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + TaskList[i]);
            }
            Console.WriteLine("----------------------------------------");
        }
    }

    public enum Menu
    {
        AddTask = 1, RemoveTask = 2, ListTask = 3, Exit = 4
    }
}
