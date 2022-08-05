// See https://aka.ms/new-console-template for more information
// Crazy - autocomplete (Github Autopilot I believe?) picked up the answer for
// me already

// use reflection to get the latest solver
var classType = typeof(BaseSolver);
var latestSolver = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(classType.IsAssignableFrom)
                .OrderByDescending(s => s.FullName)
                .First();
var solverInstance = Activator.CreateInstance(latestSolver);
if (solverInstance == null)
{
    throw new Exception("Error when finding latest solver");
}

var answer1 = solverInstance.GetType().GetProperty("Answer1").GetValue(solverInstance);
var answer2 = solverInstance.GetType().GetProperty("Answer2").GetValue(solverInstance);
Console.WriteLine($"Answer 1: {answer1}");
Console.WriteLine($"Answer 2: {answer2}");
