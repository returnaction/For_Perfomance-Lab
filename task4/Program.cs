namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            if (args.Length != 1)
            {
                Console.WriteLine("Usage: dotnet run <filename>");
                return;
            }
            string filePath = args[0];


            // путь к файлу закинул в Project - task4 Properties - Debug General - Open debug launch profile UI - in Command Line Arguments C:\Users\Oberg\OneDrive\Desktop\PortFolio\2024\ПерфомансЛаб\Perfomance-Lab\Perfomance-Lab4\file.txt

            int[] numbers;

            try
            {
                numbers = File.ReadAllLines(filePath).Select(int.Parse).ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured in reading or parsing the file: {ex.Message}");
                return;
            }

            // Найдем среднее число
            Array.Sort(numbers);
            int middleNumber = numbers[numbers.Length / 2];

            // можно было использовать built-in фунции, но я решил не блатовать и черканул обычную
            // int numberOfMoves = numbers.Sum(num => Math.Abs(num - middleNumber));

            int numberOfMoves = 0;
            foreach (int num in numbers)
            {
                int difference = num - middleNumber;
                if (difference < 0)
                {
                    difference = -difference;
                }
                numberOfMoves += difference;
            }

            Console.WriteLine(numberOfMoves);
            Console.ReadLine();
        }
    }
}
