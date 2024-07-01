using System.Text.Json;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // это для себя
            // string circleFilePath = "C:\\Users\\Oberg\\OneDrive\\Desktop\\PortFolio\\2024\\ПерфомансЛаб\\Perfomance-Lab\\Perfomance-Lab2\\File1.json";
            // string dotsFilePath = "C:\\Users\\Oberg\\OneDrive\\Desktop\\PortFolio\\2024\\ПерфомансЛаб\\Perfomance-Lab\\Perfomance-Lab2\\File2.json";

            if (args.Length < 2)
            {
                Console.WriteLine("Usage: dotnet run <circleFilePath> <dotsFilePath>");
                return;
            }

            // путь к файлу закинул в Project - task4 Properties - Debug General - Open debug launch profile UI - in Command Line Arguments два пути там:
            // string circleFilePath = "C:\\Users\\Oberg\\OneDrive\\Desktop\\PortFolio\\2024\\ПерфомансЛаб\\Perfomance-Lab\\Perfomance-Lab2\\File1.json";
            // string dotsFilePath = "C:\\Users\\Oberg\\OneDrive\\Desktop\\PortFolio\\2024\\ПерфомансЛаб\\Perfomance-Lab\\Perfomance-Lab2\\File2.json";

            string circleFilePath = args[0];
            string dotsFilePath = args[1];
            try
            {
                string circleFileJson = File.ReadAllText(circleFilePath);
                Circle circle = JsonSerializer.Deserialize<Circle>(circleFileJson);

                string dotsFilePathJson = File.ReadAllText(dotsFilePath);
                Dictionary<string, Dot> dotsDictionary = JsonSerializer.Deserialize<Dictionary<string, Dot>>(dotsFilePathJson);
                List<Dot> dots = new List<Dot>(dotsDictionary.Values);

                foreach (var dot in dots)
                {
                    double distance = Calculate(circle, dot);
                    PrintResult(circle, distance);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the data from json: \n{ex.Message}");
            }

        }

        static double Calculate(Circle circle, Dot dot)
        {
            double circleX = circle.Dot.X;
            double circleY = circle.Dot.Y;

            double dotX = dot.X;
            double dotY = dot.Y;

            return (double)Math.Sqrt(Math.Pow(dotX - circleX, 2) + Math.Pow(dotY - circleY, 2));

        }

        static void PrintResult(Circle circle, double distance)
        {
            if (distance < circle.Radius)
                Console.WriteLine("The dot is located indise of the circle");
            else if (distance > circle.Radius)
                Console.WriteLine("The dot is located outside of the circle");
            else
                Console.WriteLine("The dot is located on the radius of the circle");
        }
    }
}
