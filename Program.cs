using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            // List<Employee> employees = PeopleFetcher.GetEmployees();
            List<Employee> employees = PeopleFetcher.GetFromAPI();
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            Util.MakeBadges(employees);
        }
    }
}
