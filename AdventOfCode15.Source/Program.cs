// See https://aka.ms/new-console-template for more information
// Crazy - autocomplete (Github Autopilot I believe?) picked up the answer for
// me already

// use reflection to get the latest solver
var lines = System.IO.File.ReadAllLines(@"input.txt");
var classType = typeof(BaseSolver);
var latestSolver = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(classType.IsAssignableFrom)
                .OrderByDescending(s => s.FullName)
                .First();

// Need to use the new object[] to insert the lines array as one object,
// otherwise the params will read each line
var solverInstance = lines.Count() == 1 ?
    Activator.CreateInstance(latestSolver, lines[0]) :
    Activator.CreateInstance(latestSolver, new object[] { lines });
if (solverInstance == null)
{
    throw new Exception("Error when finding latest solver");
}

var type = solverInstance.GetType();
if (type == null)
{
    throw new Exception("Error when getting type of latest solver");
}

var a1prop = type.GetProperty("Answer1");
if (a1prop == null)
{
    throw new Exception("Error when getting Answer1 property of latest solver");
}

var a2prop = type.GetProperty("Answer2");
if (a2prop == null)
{
    throw new Exception("Error when getting Answer2 property of latest solver");
}

var answer1 = a1prop.GetValue(solverInstance);
var answer2 = a2prop.GetValue(solverInstance);

Console.WriteLine($"{type.Name}");
Console.WriteLine($"Answer 1: {answer1}");
Console.WriteLine($"Answer 2: {answer2}");
