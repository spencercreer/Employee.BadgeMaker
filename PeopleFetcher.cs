using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            while (true)
            {
                Console.WriteLine("Please enter a first name: (leave empty to exit): ");
                string firstName = Console.ReadLine();
                if (firstName == "")
                {
                    break;
                }

                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter ID: ");
                int id = Int32.Parse(Console.ReadLine());
                Console.Write("Enter Photo URL: ");
                string photoUrl = Console.ReadLine();

                // Create a new Employee instance
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }
            return employees;
        }
        public static List<Employee> GetFromAPI()
        {
            List<Employee> employees = new List<Employee>();
            using (WebClient client = new WebClient())
            {
                // Download string from randomuser api
                string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                JObject json = JObject.Parse(response);
                // Loop through each token in api response results
                foreach(JToken person in json.SelectToken("results")) {
                    Employee employee = new Employee
                    (
                        person.SelectToken("name.first").ToString(),
                        person.SelectToken("name.last").ToString(),
                        Int32.Parse(person.SelectToken("id.value").ToString().Replace("-", "")),
                        person.SelectToken("picture.large").ToString()
                    );
                    employees.Add(employee);
                }
            }
            return employees;
        }
    }
}