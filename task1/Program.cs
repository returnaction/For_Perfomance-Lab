namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = ValidInput("Enter the number of elements in the array: ");
                int m = ValidInput("Enter the interval length: ");

                int[] arr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    arr[i] = i + 1;
                }

                Console.Write("Path: ");
                int current = 0;
                do
                {
                    Console.Write(arr[current]);
                    current += m - 1;
                    if (current >= n)
                    {
                        current -= n;
                    }
                } while (current != 0);

                Console.WriteLine("\nPress \"Enter\" to try again");

                Console.ReadLine();
                Console.Clear();
            }

        }

        // сначала было две одинаковые функции я решил из них сделать один метод, типо DRY =)
        static int ValidInput(string message)
        {
            int value;
            while (true)
            {
                Console.WriteLine(message);
                if (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Wrong input. It has to be the number\n");
                    continue;
                }
                break;
            }
            return value;
        }
    }
}
