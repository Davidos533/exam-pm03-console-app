using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace PM03.Domain
{
    /// <summary>
    /// Фабрика где хранятся смартфоны (телефоны)
    /// </summary>
    public class GadgetFactory
    {
        public GadgetFactory(Smartphone[] smartphones)
        {
            Smartphones = smartphones;
        }

        /// <summary>
        /// Смартфоны
        /// </summary>
        public Smartphone[] Smartphones { get; }

        /// <summary>
        /// Сохранение массива Smartphones в файл
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        public async Task<string> SaveToFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Не указан путь!");
            }

            var serializedSmartphones = JsonSerializer.Serialize(Smartphones);

            var filePath = path.EndsWith(".json") ? path : $"{path}.json"; 

            await File.WriteAllTextAsync(filePath, serializedSmartphones);

            return filePath;
        }

        /// <summary>
        /// Сортировка по убыванию
        /// </summary>
        public void SortByDescending()
        {
            if(Smartphones == null)
            {
                throw new ArgumentException($"Массив смартфонов пуст!");
            }

            for (int i = 0; i < Smartphones.Length - 1; i++)
            {
                for (int j = 0; j < Smartphones.Length - i - 1; j++)
                {
                    var compareResult = string.Compare
                        (Smartphones[j].Model,
                        Smartphones[j + 1].Model,
                        StringComparison.Ordinal);

                    // Модель j меньше модели j + 1
                    if (compareResult < 0)
                    {
                        var buf = Smartphones[j];

                        Smartphones[j] = Smartphones[j + 1];
                        Smartphones[j + 1] = buf;
                    }

                    // Сортировка по размеру диагонали экрана
                    if (compareResult == 0 && Smartphones[j].Digonal < Smartphones[j+1].Digonal)
                    {
                        var buf = Smartphones[j];

                        Smartphones[j] = Smartphones[j + 1];
                        Smartphones[j + 1] = buf;
                    }
                }
            }
        }
    }
}
