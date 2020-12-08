using System;
using System.Collections.Generic;

namespace Day07
{
    public class Rule
    {
        public string Color { get; private set; }
        public Dictionary<int, string> Contains { get; private set; }

        public Rule(string data)
        {   
            var bagsIndex = data.IndexOf("bag");
            Color = data.Substring(0, bagsIndex - 1);

            Contains = new Dictionary<int, string>();
            var containIndex = data.IndexOf("contain");
            var containsData = data.Substring(containIndex + 8);

            if (containsData.Contains("no other bags.")) { return; }

            var containsRules = containsData.Split(',');
            foreach (var rule in containsRules)
            {
                Contains.Add(int.Parse(rule.Trim().Substring(0, 1)), "");
            }
        }
    }
}
