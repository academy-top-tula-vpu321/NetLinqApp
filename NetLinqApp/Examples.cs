using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLinqApp
{
    static class Examples
    {
        public static void SelectExample()
        {
            List<Employee> employees = new()
            {
                new() { Name = "Bob", Age = 26 },
                new() { Name = "Tom", Age = 32 },
                new() { Name = "Leo", Age = 19 },
                new() { Name = "Ben", Age = 39 },
                new() { Name = "Tim", Age = 21 },
                new() { Name = "Sam", Age = 18 },
                new() { Name = "Joe", Age = 29 },
                new() { Name = "Tom", Age = 22 },
                new() { Name = "Ben", Age = 19 },
            };

                        List<Company> companies = new()
            {
                new()
                {
                    Title = "Yandex",
                    Employees = { employees[0], employees[2], employees[4] }
                },
                new()
                {
                    Title = "Ozon",
                    Employees = { employees[1], employees[3], employees[5] }
                },
            };

            List<Employee> results = new();
            foreach (var e in employees)
                if (e.Name.StartsWith("B"))
                    results.Add(e);
            //results.Sort();
            foreach (var e in results)
                Console.WriteLine(e);
            Console.WriteLine();

            var resultsLinqQuery = from e in employees
                                   where e.Name.StartsWith("B")
                                   orderby e.Name
                                   select e;
            foreach (var e in resultsLinqQuery)
                Console.WriteLine(e);
            Console.WriteLine();

            var resultsLinqMethod = employees.Where(e => e.Name.StartsWith("B"))
                                             .OrderBy(e => e.Name)
                                             .Select(e => e);
            foreach (var e in resultsLinqMethod)
                Console.WriteLine(e);
            Console.WriteLine();

            var namesQuery = from e in employees
                             select new
                             {
                                 FirstName = e.Name,
                                 BirthYear = DateTime.Now.Year - e.Age
                             };

            foreach (var e in namesQuery.Distinct())
                Console.WriteLine($"{e.FirstName} {e.BirthYear}");
            Console.WriteLine();

            var namesMethod = employees.Select(e => new
            {
                FirstName = e.Name,
                BirthYear = DateTime.Now.Year - e.Age
            })
                                       .Distinct();

            foreach (var e in namesMethod)
                Console.WriteLine($"{e.FirstName} {e.BirthYear}");
            Console.WriteLine();


            //var employeesCompanyMethod = companies.SelectMany(c => c.Employees);
            var employeesCompanyMethod = companies.SelectMany
                (
                    c => c.Employees,
                    (c, e) => new
                    {
                        Name = e.Name,
                        Company = c.Title
                    }
                );

            foreach (var e in employeesCompanyMethod)
                //Console.WriteLine(e);
                Console.WriteLine($"{e.Name} {e.Company}");
            Console.WriteLine();

            var employeesCompanyLinq = from c in companies
                                       from e in c.Employees
                                           //select e;
                                       select new
                                       {
                                           Name = e.Name,
                                           Company = c.Title
                                       };
            foreach (var e in employeesCompanyLinq)
                //Console.WriteLine(e);
                Console.WriteLine($"{e.Name} {e.Company}");
            Console.WriteLine();
        }

        public static void WhereExample()
        {
            List<Employee> employees = new()
            {
                new() { Name = "Bob", Age = 26 },
                new() { Name = "Tom", Age = 32 },
                new() { Name = "Leo", Age = 19 },
                new() { Name = "Ben", Age = 39 },
                new() { Name = "Tim", Age = 21 },
                new() { Name = "Sam", Age = 18 },
                new() { Name = "Joe", Age = 29 },
                new() { Name = "Tom", Age = 22 },
                new() { Name = "Ben", Age = 19 },
            };

                        List<Company> companies = new()
            {
                new()
                {
                    Title = "Yandex",
                    Employees = { employees[0], employees[2], employees[4] }
                },
                new()
                {
                    Title = "Ozon",
                    Employees = { employees[1], employees[3] }
                },
                new()
                {
                    Title = "Mail",
                    Employees = { employees[0], employees[6] }
                },
                new()
                {
                    Title = "Rambler",
                    Employees = { employees[1], employees[7], employees[3] }
                },
            };

            var employees25Query = from e in employees
                                   where e.Age >= 25
                                   select e;

            foreach (var e in employees25Query)
                Console.WriteLine(e);
            Console.WriteLine();

            var employees25Method = employees.Where(e => e.Age >= 25);
            foreach (var e in employees25Method)
                Console.WriteLine(e);
            Console.WriteLine();

            Console.WriteLine(new String('-', 40));
            foreach (var c in companies)
            {
                Console.WriteLine(c.Title);
                foreach (var e in c.Employees)
                    Console.WriteLine($"\t{e}");
            }
            Console.WriteLine(new String('-', 40));

            var resultsQuery = from c in companies
                               from e in c.Employees
                               where c.Employees.Count() >= 3
                               where e.Age >= 25
                               select new
                               {
                                   FirstName = e.Name,
                                   CompanyTitle = c.Title
                               };

            foreach (var e in resultsQuery)
                Console.WriteLine($"{e.FirstName} {e.CompanyTitle}");
            Console.WriteLine();

            var resultsMethod = companies.Where(c => c.Employees.Count() >= 3)
                                         .SelectMany
                                                (
                                                    c => c.Employees,
                                                    (c, e) => new
                                                    {
                                                        FirstName = e.Name,
                                                        Age = e.Age,
                                                        CompanyTitle = c.Title
                                                    }
                                                )
                                         .Where(o => o.Age >= 25);
            foreach (var e in resultsMethod)
                Console.WriteLine($"{e.FirstName} {e.CompanyTitle}");
            Console.WriteLine();
        }
    }
}
