using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    internal class Task1
    {
        public static void Run()
        {
            List<int> array = new List<int>()
            {
                4,5,6,7,8,14,24,16,1,2,3,46
            };
            List<int> result = new List<int>();
            int choice;
            int num1, num2;
            do
            {
                Console.WriteLine("Enter what to do(1-get array, 2-get even els, 3-get odd els, 4-get bigger els, 5-get from interval, 6-get multiple by 7, 7-get multiple by 8):");
                if (!int.TryParse(Console.ReadLine(), out choice))
                    break;
                switch (choice)
                {
                    case 1:
                        result = array;
                        break;
                    case 2:
                        result = array.Where(el => el % 2 == 0).ToList();
                        break;
                    case 3:
                        result = array.Where(el => el % 2 == 1).ToList();
                        break;
                    case 4:
                        Console.Write("Enter value to compare to: ");
                        if (!int.TryParse(Console.ReadLine(), out num1))
                        {
                            result = new List<int>();
                            break;
                        }
                        result = array.Where(el => el > num1).ToList();
                        break;
                    case 5:
                        Console.Write("Enter upper and lower bounds: ");
                        string[] input = Console.ReadLine().Split(' ', ',');
                        if (input.Length != 2)
                        {
                            result = new List<int>();
                            break;
                        }
                        if (!int.TryParse(input[0], out num1) || !int.TryParse(input[1], out num2))
                        {
                            result = new List<int>();
                            break;
                        }
                        result = array.Where(el => el < Max(num1, num2) && el > Min(num1, num2)).ToList();
                        break;
                    case 6:
                        result = array.Where(el => el % 7 == 0).ToList();
                        result.Sort();
                        break;
                    case 7:
                        result = array.Where(el => el % 8 == 0).ToList();
                        result.Sort();
                        result.Reverse();
                        break;
                }
                Console.WriteLine("Result:");
                Show(result);
            } while (true);
        }

        public static int Max(int a, int b)
        {
            if (a > b)
                return a;
            return b;
        }

        public static int Min(int a, int b)
        {
            if (a < b)
                return a;
            return b;
        }

        public static void Show(List<int> array)
        {
            if (array == null)
                Console.WriteLine();
            Console.WriteLine(string.Join(", ", array));
        }
    }
    
}
