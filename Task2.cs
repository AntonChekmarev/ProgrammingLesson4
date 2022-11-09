namespace Task2 //ЗАДАЧА 26 HARD
{

    public class Task
    {
        public void Start() // === START ===
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ЗАДАЧА 26 HARD: на входе число, на выходе количество разрядов в нем, включая дробную часть.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("info: дробная часть вводится через точку");
            Console.ResetColor();

            decimal number = Input(); // ввод числа.

            Console.WriteLine("");
            Console.WriteLine($"Кол-во разрядов числа [{number.ToString().Replace(",",".")}]: " + NumberLenght(number)); //вуаля

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("* для завершения задачи нажмите любую клавишу...");
            Console.ResetColor();
            Console.ReadKey(true);
        } // === FINISH ===

        // Функция ввода и проверки данных.
        static decimal Input()
        {
            decimal rezult;
            
            Console.WriteLine("");
            do
            {
                Console.ResetColor();
                Console.Write("Введите число: ");

                string str = Console.ReadLine()!.Trim().Replace(",", "ввод дробной части красивый, когда через точку =) ").Replace(".", ","); // шаманю с точками, запятыми и боковыми пробелами

                if (str.IndexOf(" ") > -1) // пресекается возможность предоставляемая decimal.Parse() скормить ввод пробелов внутрь числа (например "1 1" = "11").
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: некорректный ввод!");

                    continue;
                }

                if (decimal.TryParse(str, out rezult) == false) // преобразование
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: некорректный ввод!");

                    continue;
                }

                break;
            } while (true);

            return rezult;
        }

        // Функция подсчета кол-ва разрядов в числе
        static int NumberLenght(decimal number)
        {
            int rezult = 0;

            // переброс целой части в дробную (иначе не стоит, ноль потеряется, если целая часть = 0)
            do
            {
                number /= 10;
            } while (Math.Truncate(number) != 0);

            do // переброс обратно с подсчетом
            {
                number *= 10;
                rezult++;
            } while (number - Math.Truncate(number) != 0);

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