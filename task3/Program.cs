using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace task3
{
    internal class Program
    {
        public static void FillTestValue(Test rootTest, Dictionary<int, string> valueDict)
        {
            // Используем очередь для итеративного обхода всех тестов
            Queue<Test> queue = new Queue<Test>();
            queue.Enqueue(rootTest);

            while (queue.Count > 0)
            {
                // Берем тест из очереди
                Test currentTest = queue.Dequeue();

                // Если тест есть, то заполняем его в словаре
                if (valueDict.ContainsKey(currentTest.Id))
                {
                    currentTest.Value = valueDict[currentTest.Id];
                }

                // Если теста нету, то ставим его в очередь
                if (currentTest.Values != null)
                {
                    foreach (var subTest in currentTest.Values)
                    {
                        queue.Enqueue(subTest);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            // это для меня
            //string valuesPath = "C:\\Users\\Oberg\\OneDrive\\Desktop\\PortFolio\\2024\\ПерфомансЛаб\\Perfomance-Lab\\Performance-Lab3\\values.json";
            //string testsPath = "C:\\Users\\Oberg\\OneDrive\\Desktop\\PortFolio\\2024\\ПерфомансЛаб\\Perfomance-Lab\\Performance-Lab3\\tests.json";
            //string reportPath = "C:\\Users\\Oberg\\OneDrive\\Desktop\\PortFolio\\2024\\ПерфомансЛаб\\Perfomance-Lab\\Performance-Lab3\\report.json";

            if (args.Length != 3)
            {
                Console.WriteLine("Usage: dotnet run <values.json> <tests.json> <report.json>");
                return;
            }

            // путь к файлу закинул в Project - task4 Properties - Debug General - Open debug launch profile UI - in Command Line Arguments два пути там:
            // C:\Users\Oberg\OneDrive\Desktop\PortFolio\2024\ПерфомансЛаб\Perfomance - Lab\Performance - Lab3\values.json
            // C:\Users\Oberg\OneDrive\Desktop\PortFolio\2024\ПерфомансЛаб\Perfomance - Lab\Performance - Lab3\tests.json
            // C:\Users\Oberg\OneDrive\Desktop\PortFolio\2024\ПерфомансЛаб\Perfomance - Lab\Performance - Lab3\report.json

            string valuesPath = args[0];
            string testsPath = args[1];
            string reportPath = args[2];

            try
            {
                string valuesJson = File.ReadAllText(valuesPath);
                ValuesFile? valuesData = JsonConvert.DeserializeObject<ValuesFile>(valuesJson);

                Dictionary<int, string> valueDict = new();
                foreach (var value in valuesData!.Values)
                {
                    valueDict[value.Id] = value.Value;
                }

                string testsJson = File.ReadAllText(testsPath);
                TestsFile? testsData = JsonConvert.DeserializeObject<TestsFile>(testsJson);
                foreach (var test in testsData!.Tests)
                {
                    FillTestValue(test, valueDict);
                }

                var reportJson = JsonConvert.SerializeObject(testsData, Formatting.Indented);
                File.WriteAllText(reportPath, reportJson);

                Console.WriteLine("Report is completed");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
