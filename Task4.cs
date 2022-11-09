namespace Task4 //ЗАДАЧА 29
{

    public class Task
    {
        public void Start() // === START ===
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ЗАДАЧА 29: на входе любое кол-во целых чисел, на выходе они же :D Плюс бонусные функции для смысла.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("info: числа перечисляются через запятую. Допустимы пробелы с обеих сторон от числа.");
            Console.ResetColor();

            int[] arrayNumbers = InputArrayNumbers(); // ввод массива чисел с разбором на запчасти

            Console.WriteLine("");
            Console.WriteLine($"Вы ввели: [{ArrayNumbersToString(arrayNumbers)}]");// вывод массива чисел со сбором обратно в строку :D

            Console.WriteLine("");
            Console.WriteLine("Кол-во чисел: " + arrayNumbers.Length); // бонус count
            Console.WriteLine("Кол-во положительных чисел: " + PNZCount(arrayNumbers, true)); // бонус +
            Console.WriteLine("Кол-во отрицательных чисел: " + PNZCount(arrayNumbers, false)); // бонус -
            Console.WriteLine("Кол-во нулей: " + PNZCount(arrayNumbers, null)); // бонус 0

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("* для завершения задачи нажмите любую клавишу...");
            Console.ResetColor();
            Console.ReadKey(true);
        } // === FINISH ===


        // Функция ввода и проверки массива целых чисел.
        static int[] InputArrayNumbers()
        {
            
            Console.WriteLine("");

        NewInput:

            Console.Write("Введите числа: ");

            string str = Console.ReadLine()!;
            
            string[] str_ = str.Split(','); // разбив на элементы

            int[] rezult = new int[str_.Length];

            for (int i = 0; i < str_.Length; i++) // цикл по координатам
            {
                string tempStr = str_[i].Trim(); // долой боковые пробелы
                
                if (int.TryParse(tempStr, out int tempInt)) // если элемент - число
                {
                    rezult[i] = tempInt; // запись элемента
                }
                else // если если элемент - НЕ число
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"err: некорректный ввод {i+1}-го элемента!");
                    Console.ResetColor();
                                       
                    goto NewInput; // поехали сначала
                }

            }

            return rezult;
        }

        //функция преобразования массива чисел в строку
        static string ArrayNumbersToString(int[] arrayNumbers, string split = ",")
        {
            string rezult = "";
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                if (i > 0) rezult += $"{split} ";
                rezult += arrayNumbers[i];
            }
            return rezult;
        }

        //функция подсчета кол-ва положительных/отрицательных/нулей в массиве чисел
        //pisitiveValue = true (для положительных)
        //pisitiveValue = false (для отрицательных)
        //pisitiveValue = null (для нулей)
        static int PNZCount(int[] arrayNumbers, bool? positiveValue)
        {
            int rezult = 0;
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                switch (positiveValue)
                {
                    case true: if (arrayNumbers[i] > 0) rezult++; // положительные
                        break;
                    case false: if (arrayNumbers[i] < 0) rezult++; // отрицательные
                        break;
                    default: if (arrayNumbers[i] == 0) rezult++; // нули
                        break;
                }
            }
            return rezult;
        }







        //На случай запуска как самостоятельно проекта, не из под Главного Меню
        class Program
        {
            static void Main()
            {
                Task task = new();
                task.Start();
            }
        }
    }
}