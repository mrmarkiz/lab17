using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    internal class Task2
    {
        public static void Run()
        {
            List<string> cities = new List<string>()
            {
                "Astan",
                "Alibaba",
                "Manchesterom",
                "Niltem",
                "Northentek",
                "Neopal",
                "Nevenkym",
                "Nesterch"
            };
            List<string> result = new List<string>();
            int choice, len;
            do
            {
                Console.WriteLine("Enter what to do(1-get cities, 2-cities with some len, 3-cities start with 'A', 4-cities end with 'M', 5-cities start with 'N' end with 'K', 6-cities start with 'Ne'):");
                if (!int.TryParse(Console.ReadLine(), out choice))
                    break;
                switch (choice)
                {
                    case 1:
                        result = cities;
                        break;
                    case 2:
                        Console.Write("Enter length to find: ");
                        if (!int.TryParse(Console.ReadLine(), out len))
                        {
                            result = null;
                            break;
                        }
                        result = cities.Where(el => el.Length == len).ToList();
                        break;
                    case 3:
                        result = cities.Where(el => el.StartsWith('A')).ToList();
                        break;
                    case 4:
                        result = cities.Where(el => el.EndsWith('m')).ToList();
                        break;
                    case 5:
                        result = cities.Where(el => (el.StartsWith('N') && el.EndsWith('k'))).ToList();
                        break;
                    case 6:
                        result = cities.Where(el => el.StartsWith("Ne")).ToList();
                        result.Sort();
                        result.Reverse();
                        break;

                }
                Console.WriteLine("Result:");
                Show(result);
            } while (true);
        }

        public static void Show(List<string> cities)
        {
            if (cities == null)
            {
                Console.WriteLine();
                return;
            }
            Console.WriteLine(string.Join(", ", cities));
        }
    }
}
