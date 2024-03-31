using NetLinqApp;

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

foreach (var e in employees)
    Console.WriteLine(e);
Console.WriteLine();

//var resultQuery = from e in employees
//                  //where e.Age >= 20
//                  orderby e.Name descending, e.Age
//                  select e;

//foreach (var e in resultQuery)
//    Console.WriteLine(e);
//Console.WriteLine();

//var resultMethod = employees.OrderByDescending(e => e.Name)
//                            .ThenBy(e => e.Age);
//foreach (var e in resultMethod)
//    Console.WriteLine(e);
//Console.WriteLine();


//Console.WriteLine(employees.Count(e => e.Age >= 25));
//Console.WriteLine(employees.Sum(e => e.Age));
//Console.WriteLine(employees.Max(e => e.Age));
//Console.WriteLine(employees.Min(e => e.Age));
//Console.WriteLine(employees.Average(e => e.Age));


int page = 3;
int items = 3;
foreach (var e in employees.Skip((page - 1) * items).Take(items))
    Console.WriteLine(e);
Console.WriteLine();