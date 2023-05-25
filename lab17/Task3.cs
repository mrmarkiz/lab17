using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace lab17
{
    internal class Task3
    {
        public static void Run()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Boris", "Brosyliv", 20, "MIT"),
                new Student("Max", "Brovski", 17, "Oxford"),
                new Student("Alex", "Brown", 25, "MIT"),
                new Student("Boris", "Welton", 22, "Oxford"),
                new Student("Brews", "Hockin", 21, "Oxford"),
                new Student("Josh", "Sanders", 18, "KPI"),
                new Student("Mary", "Johnson", 23, "Oxford")
            };
            List<Student> result = new List<Student>();

            int choice;
            do
            {
                Console.WriteLine("Enter what to do(1-all studs, 2-lastname starts with 'Bro', 3-studs 19+ yo, 4-students 20-23 yo, 5-study in 'MIT', 6-study Oxford(18+ yo):");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    break;
                }
                switch (choice)
                {
                    case 1:
                        result = students;
                        break;
                    case 2:
                        result = students.Where(stud => stud.LastName.StartsWith("Bro")).ToList();
                        break;
                    case 3:
                        result = students.Where(stud => stud.Age > 19).ToList();
                        break;
                    case 4:
                        result = students.Where(stud => stud.Age >= 20 && stud.Age <= 23).ToList();
                        break;
                    case 5:
                        result = students.Where(stud => stud.Uni == "MIT").ToList();
                        break;
                    case 6:
                        result = students.Where(stud => stud.Uni == "Oxford" && stud.Age > 18).ToList();
                        result.Sort(Student.CompareByAge);
                        break;
                }
                Console.WriteLine("Result:");
                Show(result);
            } while (true);
        }

        public static void Show(List<Student> students)
        {
            if (students == null)
                return;
            foreach (var stud in students)
            {
                Console.WriteLine(stud);
                Console.WriteLine();
            }
        }
    }

    public struct Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Uni { get; set; }

        public Student(string firstName, string lastName, int age, string uni)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Uni = uni;
        }

        public override string ToString()
        {
            return $"First name = {FirstName}\n" +
                $"Last name = {LastName}\n" +
                $"Age: {Age}\n" +
                $"Uni: {Uni}";
        }

        public static int CompareByAge(Student a, Student b)
        {
            if (a.Age > b.Age)
                return -1;
            else if (a.Age < b.Age)
                return 1;
            return 0;
        }

    }
}
/*
Отримативесь масив студентів.
Отримати список студентів з ім'ям Boris.
Отримати список студентів з прізвищем, яке починається з Bro.
Отримати список студентів, старших 19 років.
Отримати список студентів, старших 20 років і молодших 23 років.
Отримати список студентів, які навчаються в MIT.
Отримати список студентів, які навчаються в Oxford, і вік яких  старше  18  років.  
Результат  відсортуйте  за  віком,за спаданням.
 */ 