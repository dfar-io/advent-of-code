using System;
using System.Collections.Generic;
using System.Linq;

namespace Day07
{
    public class Rule
    {
        public string Color { get; private set; }
        public (string, int)[] Contains { get; private set; }

        public Rule(string data)
        {   
            var bagsIndex = data.IndexOf("bag");
            Color = data.Substring(0, bagsIndex - 1);

            var containIndex = data.IndexOf("contain");
            var containsData = data.Substring(containIndex + 8);
            if (containsData.Contains("no other bags."))
            { 
                Contains = new (string, int)[0];
                return;
            }

            var containsRules = containsData.Split(',');
            Contains = new (string, int)[containsRules.Length];
            for (int i = 0; i < Contains.Length; i++)
            {
                var count = int.Parse(containsRules[i].Trim().Substring(0, 1));
                var color = containsRules[i].Trim().Substring(2, containsRules[i].Trim().IndexOf("bag")-3);
                Contains[i] = (color, count);
            }
        }

        public bool CanContainColor(Rule[] rules, string color)
        {
            foreach (var contain in Contains)
            {
                if (contain.Item1 == color) { return true; }
                else
                {
                    var rule = rules.Where(r => r.Color == contain.Item1).FirstOrDefault();
                    if (rule.CanContainColor(rules, color))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int BagCount(Rule[] rules)
        {
            // do not include self
            return BagCount(rules, this, 1, 1) - 1;
        }

        private int BagCount(Rule[] rules, Rule rule, int bagCount, int multiplier)
        {
            int sum = 0;
            foreach (var contain in rule.Contains)
            {
                var nextRule = rules.Where(r => r.Color == contain.Item1).FirstOrDefault();
                sum += BagCount(rules, nextRule, contain.Item2, bagCount);
            }

            return (sum + bagCount) * multiplier;
        }
    }
}
