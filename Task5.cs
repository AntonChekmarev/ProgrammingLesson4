namespace Task5 //ЗАДАЧА 30 HARD
{

    public class Task
    {
        public void Start() // === START ===
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ЗАДАЧА 30 HARD: на входе кол-во элементов массива, который заполняется нулями и единицами в случайном порядке.");
            Console.WriteLine("На выходе: 'TRUE' - если единиц в массиве больше, чем нулей. 'FALSE' - если меньше или одинаково.");
            Console.ResetColor();

            int arrayCount = Input(); // ввод кол-ва элементов

            int[] arrayNumbers = ArrayRandom(arrayCount); // формирование массива

            Console.WriteLine("");
            Console.WriteLine($"Элементы: [{ArrayNumbersToString(arrayNumbers)}]");// вывод массива чисел

            Console.WriteLine("");
            Console.WriteLine("Результат: " + (NumberCount(arrayNumbers, 1) > NumberCount(arrayNumbers, 0) ? "TRUE" : "FALSE"));// вуаля


            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("* для завершения задачи нажмите любую клавишу...");
            Console.ResetColor();
            Console.ReadKey(true);
        } // === FINISH ===


        // Функция ввода и проверки данных.
        static int Input()
        {
            int rezult;
            
            Console.WriteLine("");
            do
            {
                Console.ResetColor();
                Console.Write("Задайте кол-во элементов: ");

               string str = Console.ReadLine()!.Trim();

                if (int.TryParse(str, out rezult) == false) // преобразование
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: неcоответствие типу Integer!");

                    continue;
                }

                if (rezult <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: количество должно быть натуральным числом!");

                    continue;
                }

                break;
            } while (true);

            return rezult;
        }

        //функция формирования массива со случайными элеменатми в задаваемом дипазоне
        int[] ArrayRandom(int count, int min = 0, int max = 1)
        {
            int[] rezult = new int[count];

            Random rnd = new();

            for (int i = 0; i < count; i++)
            {
                rezult[i] = rnd.Next(min, max+1);
            }

            return rezult;
        }

        //функция подсчета кол-ва чисел в массиве
        static int NumberCount(int[] arrayNumbers, int number)
        {
            int rezult = 0;
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                if (arrayNumbers[i] == number) rezult++;
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