namespace Task1 //ЗАДАЧА 25
{   
    public class Task
    {       
        public void Start() // === START ===
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ЗАДАЧА 25: на входе два значения: число и степень. На выходе результат возведения числа в степень.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("info: дробная часть вводится через точку");
            Console.ResetColor();
                        
            double a = Input(false); // ввод числа.
            double b = Input(true, a); // ввод степени. 

            Console.WriteLine("");           
            Console.WriteLine(($"Результат возведения числа [{a}] в степень [{b}]: " + Math.Pow(a, b).ToString("0.###############")).Replace(",",".")); //вуаля

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("* для завершения задачи нажмите любую клавишу...");
            Console.ResetColor();
            Console.ReadKey(true);
        } // === FINISH ===

        // Функция ввода и проверки данных.
        // Параметр pow = True (когда степень) или False (когда число).
        // Параметр a = ранее веденное числу А, если сейчас вводится степень. Если же сейчас вводится само число А, то параметр опустить.
        static double Input(bool pow, double number = 0)
        {
            double rezult;
        
            Console.WriteLine("");
            do
            {
                Console.ResetColor();
                Console.Write("Введите " + ((pow) ? "степень" : "число")+ ": ");

              string str = Console.ReadLine()!.Trim().Replace(",", "ввод дробной части красивый, когда через точку =) ").Replace(".", ","); // шаманю с точками, запятыми и боковыми пробелами

                if (str.IndexOf(" ") > -1) // пресекается возможность предоставляемая double.Parse() скормить ввод пробелов внутрь числа (например "1 1" = "11").
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: некорректный ввод!");

                    continue;
                }


                if (double.TryParse(str, out rezult) == false) // преобразование
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: некорректный ввод!");

                    continue;
                }

                if (pow) // проверяем степень
                {
                    if (number < 0 && (rezult - Math.Truncate(rezult) != 0)) //если при отрицательном числе скормили нецелую степень 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("err: отрицательное число нельзя возвести в нецелую степень!");

                        continue;
                    }

                    if (number == 0 && rezult < 0 ) //если при нуле скормили отрицательную степень 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("err: ноль нельзя возводить в отрицательную степень!");

                        continue;
                    }
                }

                break;
            } while (true);
            return rezult;
        }
       
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