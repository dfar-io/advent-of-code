public class S16 : BaseSolver
{
    public S16(string[] input) : base(input)
    {
        var data = new List<Sue>();
        foreach (var line in _input)
        {
            var parts = line.Split(" ");
            var number = int.Parse(parts[1].TrimEnd(':'));
            var prop1 = parts[2].TrimEnd(':');
            var prop1Value = int.Parse(parts[3].TrimEnd(','));
            var prop2 = parts[4].TrimEnd(':');
            var prop2Value = int.Parse(parts[5].TrimEnd(','));
            var prop3 = parts[6].TrimEnd(':');
            var prop3Value = int.Parse(parts[7].TrimEnd(','));

            data.Add(new Sue(number, prop1, prop1Value, prop2, prop2Value, prop3, prop3Value));
        }

        var correctSueNumber = 0;
        foreach (var sue in data)
        {
            if (sue.HasMismatchingProperty("children", 3)) { continue; }
            if (sue.HasLessThanOrEqualProperty("cats", 7)) { continue; }
            if (sue.HasMismatchingProperty("samoyeds", 2)) { continue; }
            if (sue.HasGreaterThanOrEqualProperty("pomeranians", 3)) { continue; }
            if (sue.HasMismatchingProperty("akitas", 0)) { continue; }
            if (sue.HasMismatchingProperty("vizslas", 0)) { continue; }
            if (sue.HasGreaterThanOrEqualProperty("goldfish", 5)) { continue; }
            if (sue.HasLessThanOrEqualProperty("trees", 3)) { continue; }
            if (sue.HasMismatchingProperty("cars", 2)) { continue; }
            if (sue.HasMismatchingProperty("perfumes", 1)) { continue; }

            correctSueNumber = sue.Number;
        }

        // Change all to use HasMismatchingProperty to get answer 1
        Answer2 = correctSueNumber.ToString();
    }

    private class Sue
    {
        public int Number { get; private set; }
        public Dictionary<string, int> Properties { get; private set; }

        public Sue(int number, string prop1, int prop1Value, string prop2, int prop2Value, string prop3, int prop3Value)
        {
            Number = number;
            Properties = new Dictionary<string, int>();
            Properties.Add(prop1, prop1Value);
            Properties.Add(prop2, prop2Value);
            Properties.Add(prop3, prop3Value);
        }

        public bool HasMismatchingProperty(string propName, int value)
        {
            var propValue = GetPropertyValue(propName);
            if (propValue == -1) { return false; }

            return propValue != value;
        }

        public bool HasLessThanOrEqualProperty(string propName, int value)
        {
            var propValue = GetPropertyValue(propName);
            if (propValue == -1)
            {
                return false;
            }

            return propValue <= value;
        }

        public bool HasGreaterThanOrEqualProperty(string propName, int value)
        {
            var propValue = GetPropertyValue(propName);
            if (propValue == -1) { return false; }

            return propValue >= value;
        }

        private int GetPropertyValue(string propName)
        {
            if (!Properties.TryGetValue(propName, out var value)) {
                return -1;
            }

            return value;
        }
    }
}