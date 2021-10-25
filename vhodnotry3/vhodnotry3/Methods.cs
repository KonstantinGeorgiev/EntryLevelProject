using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace vhodnotry3
{
    class Methods
    {
        public Methods()
        {
            string user = Console.ReadLine();
            Console.WriteLine();
            List<Workers> workers = new List<Workers>();
            if (user == "Guest")
            {
                UserUser();
            }
            else if (user == "Admin")
            {
                UserAdmin();
            }
           
        }
        static void UserUser()
        {
            List<Workers> workers = new List<Workers>();
            using (StreamReader streamReader = new StreamReader("TextFile1.txt"))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] input = line.Split('/');
                    Workers neznam = new Workers();

                    neznam.FirstName = input[0];
                    neznam.MiddleName = input[1];
                    neznam.LastName = input[2];
                    neznam.Address = input[3];
                    neznam.Number = int.Parse(input[4]);
                    neznam.Salary = double.Parse(input[5]);

                    workers.Add(neznam);
                }
            }
            Console.WriteLine("1: View");
            Console.WriteLine("2: Sort");
            Console.WriteLine("3: Exit");
            Console.WriteLine();
            int action = int.Parse(Console.ReadLine());
            Console.WriteLine();

            while (action != 3)
            {
                if (action == 1)
                {
                    UsersView(workers);
                }
                else if (action == 2)
                {
                    Console.WriteLine("1: Sort by first name");
                    Console.WriteLine("2: Sort by second name");
                    Console.WriteLine("3: Sort by address");
                    

                    Console.Write("Sorting by ");
                    string option = Console.ReadLine();

                    if (option == "first name")
                    {
                        workers = workers.OrderBy(a => a.FirstName).ToList();
                    }
                    else if (option == "last name")
                    {
                        workers = workers.OrderBy(b => b.LastName).ToList();
                    }
                    else if (option == "address")
                    {
                        workers = workers.OrderBy(c => c.Address).ToList();
                    }                 
                    else
                    {
                        Console.WriteLine("Wrong input!");

                    }
                }
                else if (action == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong action!");
                }
                Console.WriteLine();

                Console.WriteLine("1: View");
                Console.WriteLine("2: Sort");
                Console.WriteLine("3: Exit");
                Console.WriteLine();
                action = int.Parse(Console.ReadLine());
            }

        }
        static void UserAdmin()
        {
            List<Workers> workers = new List<Workers>();
            using (StreamReader streamReader = new StreamReader("TextFile1.txt"))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] input = line.Split('/');
                    Workers neznam = new Workers();

                    neznam.FirstName = input[0];
                    neznam.MiddleName = input[1];
                    neznam.LastName = input[2];
                    neznam.Address = input[3];
                    neznam.Number = int.Parse(input[4]);
                    neznam.Salary = double.Parse(input[5]);

                    workers.Add(neznam);
                }
            }
            Console.WriteLine("1: Add");
            Console.WriteLine("2: Remove");
            Console.WriteLine("3: View");
            Console.WriteLine("4: Sort");
            Console.WriteLine("5: Exit");
            Console.WriteLine();
            int action = int.Parse(Console.ReadLine());
            Console.WriteLine();

            while (action != 5)
            {
                if (action == 1)
                {
                    Add(workers);
                }
                else if (action == 2)
                {
                    Remove(workers);
                }
                else if (action == 3)
                {
                    UsersAdmin(workers);
                }
                else if (action == 4)
                {
                    Console.WriteLine("1: Sort by first name");
                    Console.WriteLine("2: Sort by second name");
                    Console.WriteLine("3: Sort by address");
                    Console.WriteLine("4: Sort by salary");

                    Console.Write("Sort by ");
                    string option = Console.ReadLine();

                    if (option == "first name")
                    {
                        workers = workers.OrderBy(a => a.FirstName).ToList();
                    }
                    else if (option == "second name")
                    {
                        workers = workers.OrderBy(b => b.LastName).ToList();
                    }
                    else if (option == "address")
                    {
                        workers = workers.OrderBy(c => c.Address).ToList();
                    }
                    else if (option == "salary")
                    {
                        workers = workers.OrderBy(d => d.Salary).ToList();
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!");

                    }
                }
                else if (action == 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong action!");

                }

                Console.WriteLine();
                Console.WriteLine("1: Add");
                Console.WriteLine("2: Remove");
                Console.WriteLine("3: View");
                Console.WriteLine("4: Sort");
                Console.WriteLine("5: Exit");
                Console.WriteLine();

                action = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
        }
        static void Add(List<Workers> a)
        {

            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= n; i++)
            {
                Workers workerneew = new Workers();
                Console.WriteLine($"Enter info about your {n} new workers");
                string[] readEmployee = Console.ReadLine().Split('/').ToArray();
                Console.WriteLine();

                workerneew.FirstName = readEmployee[0];
                workerneew.MiddleName = readEmployee[1];
                workerneew.LastName = readEmployee[2];
                workerneew.Address = readEmployee[3];
                workerneew.Number = int.Parse(readEmployee[4]);
                workerneew.Salary = double.Parse(readEmployee[5]);

                a.Add(workerneew);

                using (StreamWriter streamWriter = new StreamWriter("TextFile.txt", true))
                {
                    streamWriter.WriteLine($"{workerneew.FirstName} {workerneew.MiddleName} {workerneew.LastName} {workerneew.Address} {workerneew.Number} {workerneew.Salary}");
                }
            }

            Console.WriteLine("User added!");
            Console.WriteLine();
        }
        static void Remove(List<Workers> people)
        {

            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter info about the {n} workers you are firing");
                string employeeToFire = Console.ReadLine();

                string[] readText = File.ReadAllLines("TextFile1.txt");
                File.WriteAllText("TextFile1.txt", String.Empty);

                using (StreamWriter streamWriter = new StreamWriter("TextFile1.txt", true))
                {
                    foreach (var line in readText)
                    {
                        if (!line.Equals(employeeToFire))
                        {
                            streamWriter.WriteLine(line);
                        }
                    }
                }
            }

            people.Clear();
            using (StreamReader streamReader = new StreamReader("TextFile1.txt"))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] input = line.Split().ToArray();
                    Workers workerTwo = new Workers();
                    workerTwo.FirstName = input[0];
                    workerTwo.MiddleName = input[1];
                    workerTwo.LastName = input[2];
                    workerTwo.Address = input[3];
                    workerTwo.Number = int.Parse(input[4]);
                    workerTwo.Salary = double.Parse(input[5]);

                    people.Add(workerTwo);
                }
            }
        }
        static void UsersAdmin(List<Workers> workers)
        {
            foreach (var employee in workers)
            {
                Console.WriteLine(employee.PrintWorkersAdmin());
            }
        }
        static void UsersView(List<Workers> workers)
        {
            foreach (var employee in workers)
            {
                Console.WriteLine(employee.PrintWorkersUser());
            }
        }
    }
}
