using PM03.Domain;
using System;
using System.Globalization;

namespace PM03.ConsoleApp
{
    /// <summary>
    /// Класс точки входа в программа
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Метод точки входа в программу
        /// </summary>
        /// <param name="args">Агрументы запуска консольного приложения</param>
        static void Main(string[] args)
        {
            var arrSize = 0;

            while (!SafeExec(() =>
            {
                Console.Write("Введите размер массива: ");
                arrSize = int.Parse(Console.ReadLine());

                if (arrSize < 0 || arrSize > int.MaxValue)
                {
                    throw new ArgumentException($"Некорректный размер масива, допустимый размер от {0} до {int.MaxValue}");
                }
            }, $"Неверный формат размера массива. Допустимые знчения от {0} до {int.MaxValue}"));

            var smartphones = new Smartphone[arrSize];

            for (int i = 0; i < arrSize; i++)
            {
                smartphones[i] = InputSmartphone();
            }

            var factory = new GadgetFactory(smartphones);

            factory.SortByDescending();

            while (!SafeExec(()=>
            {
                Console.Write("Введите путь куда сохранить файл: ");
                var path = Console.ReadLine();

                var savedPath = factory.SaveToFile(path).Result;

                Console.WriteLine($"Файл сохранён по пути {savedPath}");
            }, "Некорректный путь к файлу"));
        }

        private static Smartphone InputSmartphone()
        {
            var s = new Smartphone();

            while (!SafeExec(()=>
            {
                Console.Write("Введите модель (строка): ");
                s.Model = Console.ReadLine();

                Console.Write("Ведите цену (десятичное число, через запятую): ");
                s.Price = decimal.Parse(Console.ReadLine());

                Console.Write("Ведите диагональ (десятичное число, через запятую): ");
                s.Digonal = double.Parse(Console.ReadLine());
            }));

            return s;
        }

        /// <summary>
        /// Безопасное выпонение действия
        /// </summary>
        /// <param name="action">Действие</param>
        /// <param name="errMessage">Сообщение об ошибке</param>
        /// <returns>Успешность выполнения</returns>
        private static bool SafeExec(Action action, string errMessage = default)
        {
            try
            {
                action();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(errMessage == default ? ex.Message : errMessage);
                return false;
            }
        }
    }
}