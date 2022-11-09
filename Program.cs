using System.Reflection;

try
{
    PrintMainMenu();

    ConsoleKey key;

    int taskNumber = 0;
    
    do
    {
        key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1) taskNumber = 1; // [1]
        if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2) taskNumber = 2; // [2]
        if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3) taskNumber = 3; // [3]
        if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4) taskNumber = 4; // [4]
        if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5) taskNumber = 5; // [5]
   
        if (taskNumber != 0)
        {
            try
            {
                Assembly asm = Assembly.LoadFrom(Assembly.GetExecutingAssembly().Location); // исполняемый файл
                Type t = asm.GetExportedTypes().Where(a => a.FullName.Contains($"Task{taskNumber}")).FirstOrDefault()!; // нужная задача
                t.GetMethod("Start")!.Invoke(t.GetConstructor(Type.EmptyTypes)!.Invoke(new object[] { }), null); //запуск задачи
                // t.GetMethod("Start")!.Invoke(null, null); // онли статика
            }
            catch (Exception e)
            {
                ExceptionMessage(e.Message);                   
            }
            taskNumber = 0;
            PrintMainMenu();
        }
    }
    while (key != ConsoleKey.Escape);
}
catch (Exception e)
{
    ExceptionMessage(e.Message);
}

// наименования пунктов меню
string MenuItemName(int taskNamber)
{
    switch (taskNamber)
    {
        case 1: return "Задача № 25"; // Task1.cs
        case 2: return "Задача № 26 HARD"; // Task2.cs
        case 3: return "Задача № 27"; // Task3.cs
        case 4: return "Задача № 29"; // Task4.cs
        case 5: return "Задача № 30 HARD"; // Task5.cs
        default: return "?";

    }
}

// отрисовка главного меню
void PrintMainMenu()
{
    Console.Clear();
    Console.ResetColor();

    string keys = "";
    for (int i = 1; i <=5; i++)
    {
        Console.WriteLine("");
        Console.WriteLine($"[{i}] - {MenuItemName(i)}");
        keys += $" [{i}]";
    }

    Console.WriteLine("");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write($"* инициируйте выполнение Задач клавишами{keys} или нажмите [Esc] для выхода из программы...");
    Console.ResetColor();
}

// вывод исключения
void ExceptionMessage(string eMessage)
{
    Console.WriteLine("");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine($"критическая ошибка: {eMessage}");    
    Console.WriteLine("");
    Console.Write("* нажмите любую клавишу...");
    Console.ResetColor();
    Console.ReadKey(true);
}
