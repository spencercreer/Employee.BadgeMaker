using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees;
            Console.WriteLine("Would you like to enter employee information? (y/n): ");
            string response1 = Console.ReadLine();
            if (response1 == "y" || response1 == "yes" || response1 == "Yes")
            {
                employees = PeopleFetcher.GetEmployees();
                Util.PrintEmployees(employees);
                Util.MakeCSV(employees);
                Util.MakeBadges(employees);
            }

            Console.WriteLine("Would you like to fetch employee data from the API? (y/n): ");
            string response2 = Console.ReadLine();
            if (response2 == "y" || response2 == "yes" || response2 == "Yes")
            {
                employees = PeopleFetcher.GetFromAPI();
                Util.PrintEmployees(employees);
                Util.MakeCSV(employees);
                Util.MakeBadges(employees);
            }
        }
    }
}
