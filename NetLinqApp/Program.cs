using NetLinqApp;

List<Author> authorList = new()
{
    new() { Id = 1, Name = "Pushkin" },
    new() { Id = 2, Name = "Dostoevsky" },
    new() { Id = 3, Name = "Tolstoy" },
};

List<Book> books = new()
{
    new() { IdAuthor = 1, Title = "Evgeny Onegin" },
    new() { IdAuthor = 2, Title = "Besy" },
    new() { IdAuthor = 3, Title = "Anna Karenina" },
    new() { IdAuthor = 1, Title = "Ruslan and Ludmila" },
    new() { IdAuthor = 3, Title = "War and Piece" },
    new() { IdAuthor = 2, Title = "Belie Nochy" },
    new() { IdAuthor = 1, Title = "Dubrovsky" },
    new() { IdAuthor = 1, Title = "Zolotaya Rybka" },
};


List<Company> companies = new List<Company>()
{
    new() { Title = "Yandex" },
    new() { Title = "Ozon" },
    new() { Title = "Mail Group" },
};

List<Employee> employees = new()
{
    new() { Name = "Bob", Age = 26, Company = companies[0] },
    new() { Name = "Tom", Age = 32, Company = companies[1] },
    new() { Name = "Leo", Age = 19, Company = companies[2] },
    new() { Name = "Ben", Age = 39, Company = companies[1] },
    new() { Name = "Tim", Age = 21, Company = companies[0] },
    new() { Name = "Sam", Age = 18, Company = companies[1] },
    new() { Name = "Joe", Age = 29, Company = companies[2] },
    new() { Name = "Tom", Age = 22, Company = companies[1] },
    new() { Name = "Ben", Age = 19, Company = companies[0] },
};

/*
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
*/

//foreach (var e in employees)
//    Console.WriteLine(e);
//Console.WriteLine();

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


//int page = 3;
//int items = 3;
//foreach (var e in employees.Skip((page - 1) * items).Take(items))
//    Console.WriteLine(e);
//Console.WriteLine();

//var groupQuery = from e in employees
//                 group e by e.Company;

//foreach(var c in groupQuery)
//{
//    Console.WriteLine($"Company: {c.Key.Title}");
//    foreach(var e in c)
//        Console.WriteLine($"\t{e}");
//}

//var groupMethod = employees.GroupBy(e => e.Company);
//foreach (var c in groupMethod)
//{
//    Console.WriteLine($"Company: {c.Key.Title}");
//    foreach (var e in c)
//        Console.WriteLine($"\t{e}");
//}

//var compCountQuery = from e in employees
//                     group e by e.Company into empls
//                     select new
//                     {
//                         TitleCompany = empls.Key.Title,
//                         CountEmployees = empls.Count()
//                     };

//foreach (var c in compCountQuery)
//{
//    Console.WriteLine($"Company: {c.TitleCompany} Count: {c.CountEmployees}");
//}

//var compCountMethod = employees.GroupBy(e => e.Company)
//                               .Select(em => new 
//                               {
//                                   TitleCompany = em.Key.Title,
//                                   CountEmployees = em.Count()
//                               });

//foreach (var c in compCountMethod)
//{
//    Console.WriteLine($"Company: {c.TitleCompany} Count: {c.CountEmployees}");
//}

var emplJoinQuery = from b in books
                    join a in authorList
                        on b.IdAuthor equals a.Id
                    select new
                    {
                        Name = a.Name,
                        Title = b.Title
                    };

foreach(var item in emplJoinQuery)
    Console.WriteLine($"{item.Name} {item.Title}");
Console.WriteLine();

var emplJoinMethod = books.Join(
    authorList,
    b => b.IdAuthor,
    a => a.Id,
    (b, a) => new
    {
        Name = a.Name,
        Title = b.Title
    });

foreach (var item in emplJoinMethod)
    Console.WriteLine($"{item.Name} {item.Title}");