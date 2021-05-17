using System;

namespace ConsoleApp1._1
{
    class Student
    {
        public string name { get; set; }
        public string course { get; set; }
        public int number { get; set; }

        public Student(string name, string course , int number)
        {
            this.name = name;
            this.course = course;
            this.number = number;
        }
        public virtual void Print()
        {
            Console.WriteLine($"Last name : {name}\tCourse of Study : {course}\tGrade book number : {number}");
        }
    }


    class Aspirant : Student
    {
        public string thesisTitle { get; set; }
        public Aspirant(string name, string course, int number,string thesis) : base(name, course, number)
        {
            thesisTitle = thesis;
        }
        public override void Print()
        {
            Console.WriteLine($"Last name : {name}\tCourse of Study : {course}\tGrade book number : {number}\tThesis title is {thesisTitle}");
        }
    }

    class People
    {
        Student[] data;

        public People()
        {
            data = new Student[100];
        }

        public Student this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
    }

    class Program
    {
        static Student[] students = new Student[100];
        static Aspirant[] aspirants = new Aspirant[100];
        public static int numberOfStudents = 0;
        public static int numberOfAspirants = 0;
        public static int indexOfStudents = 0;
        public static int indexOfAspirants = 0;


        //indexer
        static People people = new People();
        static int indexerPosition = 0;


        static void Main(string[] args)
        {
            int menu = -1;
            int id;

            while (menu != 0)
            {
                Console.WriteLine("0. Exit application\n" +
             "1. Create Student \n" +
             "2. Create Aspirant \n" +
             "3. Number of Students\n" +
             "4. Number of Aspirants\n" +
             "5. List of all Students\n" +
             "6. List of all Aspirants\n" +
             "7. Print Student by Id\n" +
             "8. Print Aspirant by id\n" +
             "9. Remove Student by id\n" +
             "10. Remove Aspirant by id\n" +
             "11. Print all using indexer (Task with indexer)");

                menu = inputNumber();
                    switch (menu)
                    {
                        case 1:
                            createStudent();
                            break;
                        case 2:
                            createAspirant();
                            break;
                        case 3:
                            printNumberOfStudents();
                            break;
                        case 4:
                            printNumberOfAspirants();
                            break;
                        case 5:
                            printAllStudents();
                            break;
                        case 6:
                            printAllAspirants();
                            break;
                        case 7:
                            Console.WriteLine("Print student id:");
                            id = inputNumber();
                            printStudentById(id);
                            break;
                        case 8:
                            Console.WriteLine("Print aspirant id:");
                            id = inputNumber();
                            printAspirantById(id);
                            break;
                        case 9:
                            Console.WriteLine("Print student id:");
                            id = inputNumber();
                            removeStudentById(id);
                            break;
                        case 10:
                            Console.WriteLine("Print aspirant id:");
                            id = inputNumber();
                            removeAspirantById(id);
                            break;

                        case 11:
                            Console.WriteLine("Print person id:");
                            id = inputNumber();
                            printPeopleWithIndexer(id);

                            break;
                        default:
                            menu = 0;
                            break;
                    }

            }

            
            Console.ReadKey();

        }

        public static void createStudent()
        {
            string name, course;
            int number;

            Console.WriteLine("Enter name of the Student:");
            name = Console.ReadLine();
            Console.WriteLine("Enter course of the Student:");
            course = Console.ReadLine();
            Console.WriteLine("Enter number of the Student:");
            for(; ; )
            {
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out number))
                {
                    number = Convert.ToInt32(number);

                    students[indexOfStudents] = new Student(name, course, number);
                    numberOfStudents++;
                    indexOfStudents++;

                    //For indexer
                    people[indexerPosition] = new Student(name, course, number);
                    indexerPosition++;

                    return;
                }
                else
                {
                    Console.WriteLine("Enter a number");
                }
            }
        }

        public static void createAspirant()
        {
            string name, course, thesisTitle;
            int number;

            Console.WriteLine("Enter name of the Aspirant:");
            name = Console.ReadLine();
            Console.WriteLine("Enter course of the Aspirant:");
            course = Console.ReadLine();
            Console.WriteLine("Enter number of the Aspirant:");
            for (; ; )
            {
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out number))
                {
                    number = Convert.ToInt32(number);

                    Console.WriteLine("Enter title of the Aspirant's thesis:");
                    thesisTitle = Console.ReadLine();

                    students[indexOfStudents] = new Aspirant(name, course, number, thesisTitle);
                    aspirants[indexOfAspirants] = new Aspirant(name, course, number, thesisTitle);

                    numberOfStudents++;
                    numberOfAspirants++;
                    indexOfAspirants++;
                    indexOfStudents++;

                    //For indexer
                    people[indexerPosition] = new Aspirant(name, course, number, thesisTitle);
                    indexerPosition++;

                    return;
                }
                else
                {
                    Console.WriteLine("Enter a number");
                }
            }
           
        }

        public static int inputNumber()
        {
            for (; ; )
            {
                int result;
                string message = Console.ReadLine();
                if (Int32.TryParse(message, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Enter number");
                }
            }
        }

        public static void printNumberOfStudents()
        {
            Console.WriteLine($"There are: { numberOfStudents } students");
        }

        public static void printNumberOfAspirants()
        {
            Console.WriteLine($"There are: { numberOfAspirants } aspirants");
        }

        public static void printAllStudents()
        {
            if(indexOfStudents == 0)
            {
                Console.WriteLine("There are no students yet!");

                return;
            }
            for(int i = 0; i < indexOfStudents; i++)
            {
                if(students[i] != null)
                Console.WriteLine($"{students[i].name} {students[i].course} {students[i].number}");
            }
        }

        public static void printAllAspirants()
        {
            if (indexOfAspirants == 0)
            {
                Console.WriteLine("There are no aspirants yet!");

                return;
            }
            for (int i = 0; i < indexOfAspirants; i++)
            {
                if (aspirants[i] != null)
                    Console.WriteLine($"{aspirants[i].name} {aspirants[i].course} {aspirants[i].number} {aspirants[i].thesisTitle}");
            }
        }

        public static void printStudentById(int id)
        {
            if (id <= 0 || id > 100 || students[id-1] == null)
            {
                Console.WriteLine($"There are no student with id {id}");

            }
            else
            {
                Console.WriteLine($"{students[id-1].name} {students[id-1].course} {students[id-1].number}");
            }
            
        }

        public static void printAspirantById(int id)
        {
            if (id <= 0 || id > 100 || aspirants[id - 1] == null)
            {
                Console.WriteLine($"There are no aspirant with id {id}");

            }
            else
            {
                Console.WriteLine($"{aspirants[id - 1].name} {aspirants[id - 1].course} {aspirants[id - 1].number} {aspirants[id-1].thesisTitle}");
            }

        }

        public static void removeAspirantById(int id)
        {
            if (id <= 0 || id > 100 || aspirants[id - 1] == null)
            {
                Console.WriteLine($"There are no aspirant with id {id}");

            }
            else
            {
                for (int i = 0; i < indexOfStudents; i++)
                {
                    if (students[i].name == aspirants[id-1].name && students[i].course == aspirants[id - 1].course 
                        && students[i].number == aspirants[id - 1].number)
                        students[i] = null;
                }
                aspirants[id - 1] = null;
                Console.WriteLine("Aspirant deleted!");
                numberOfAspirants--;
                numberOfStudents--;
            }

        }

        public static void removeStudentById(int id)
        {
            if (id <= 0 || id > 100 || students[id - 1] == null)
            {
                Console.WriteLine($"There are no student with id {id}");

            }
            else
            {
                if(students[id-1].GetType() == typeof(Aspirant))
                {
                    for(int i = 0; i < indexOfAspirants; i++)
                    {
                        if (students[id - 1].name == aspirants[i].name && students[id - 1].course == aspirants[i].course &&
                            students[id - 1].number == aspirants[i].number)
                            aspirants[i] = null;
                    }
                    numberOfAspirants--;
                }
                students[id - 1] = null;
                Console.WriteLine("Student deleted!");
                numberOfStudents--;
            }

        }

        public static void printPeopleWithIndexer(int id)
        {
            if (id <= 0 || id > 100 || people[id - 1] == null)
            {
                Console.WriteLine($"There are no people with id {id}");
            }
            else
            {
                Console.WriteLine($"{people[id - 1].name} {people[id - 1].course} {people[id - 1].number}");
            }
        }
    }
}
