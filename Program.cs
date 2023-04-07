
List<string> TaskList = new List<string>();
         
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

int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string line = Console.ReadLine();
    return Convert.ToInt32(line);
}

void ShowTaskRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");

        getTaskList();

        string line = Console.ReadLine();
        // Remove one position because the array starts in 0
        int indexToRemove = Convert.ToInt32(line) - 1;
        if(indexToRemove < 0 || indexToRemove > (TaskList.Count - 1))
            Console.WriteLine("El numero de tarea seleccionado no existe");
        else if(indexToRemove > -1 && TaskList.Count > 0)
        {
            string task = TaskList[indexToRemove];
            TaskList.RemoveAt(indexToRemove);
            Console.WriteLine($"Tarea {task} eliminada");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al seleccionar la tarea a eliminar");
    }
}

void ShowTaskAdd()
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
        Console.WriteLine("Ha ocurrido un error al adicionar tarea");
    }
}

void ShowTaskList()
{
    if (TaskList?.Count > 0)
        getTaskList();
    else
        Console.WriteLine("No hay tareas por realizar");
}

void getTaskList()
{
    Console.WriteLine("----------------------------------------");
    var index = 1;
    TaskList.ForEach(list => Console.WriteLine($"{index++} . {list}"));
    Console.WriteLine("----------------------------------------");
}

enum Menu
{
    AddTask = 1, RemoveTask = 2, ListTask = 3, Exit = 4
}
