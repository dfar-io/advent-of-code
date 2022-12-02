using System.Text.RegularExpressions;

public class S19 : BaseSolver
{
    public S19(string[] input) : base(input)
    {
        var replacements = new List<KeyValuePair<string, string>>();
        var initialMolecule = "";
        var molecules = new HashSet<string>();

        // Initialize data from input
        foreach (var line in input)
        {
            if (line.Contains("=>"))
            {
                var parts = line.Split(" => ");
                replacements.Add(new KeyValuePair<string, string>(parts[0], parts[1]));
            }
            else if (line.Length > 0)
            {
                initialMolecule = line;
            }
        }

        // We should split the initial molecule into upper/lowercase parts
        // Then loop through it with a foreach
        string[] initialMoleculeSplit =  Regex.Split(initialMolecule, @"(?<!^)(?=[A-Z])");
        for (var i = 0; i < initialMoleculeSplit.Length; i++)
        {
            var eligibleReplacements = replacements.Where(x => x.Key == initialMoleculeSplit[i]);
            foreach (var replacement in eligibleReplacements)
            {
                var newMolecule = string.Join("", initialMoleculeSplit, 0, i) +
                                  replacement.Value +
                                  string.Join("", initialMoleculeSplit, i + 1, initialMoleculeSplit.Length - i - 1);
                molecules.Add(newMolecule);
            }
        }

        // 189 too low, need to collect 
        _answer1 = molecules.Count().ToString();
    }
}