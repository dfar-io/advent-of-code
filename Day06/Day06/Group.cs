using System;
using System.Linq;

namespace Day06
{
    public class Group
    {
        public int PeopleCount { get; private set; }
        public char[] QuestionsAnsweredYesByAnyone { get; private set; }
        public char[] QuestionsAnsweredYesByEveryone { get; private set; }

        public Group(string data)
        {
            var individualAnswers = data.Split("\n");
            PeopleCount = individualAnswers.Length;

            var anyoneSequence = "";
            var everyoneSequence = individualAnswers.First();
            foreach (var answer in individualAnswers)
            {
                anyoneSequence += answer;
                anyoneSequence = new String(anyoneSequence.Distinct().ToArray());

                everyoneSequence += answer;
                everyoneSequence = ResolveEveryOneSequence(everyoneSequence);
            }
            QuestionsAnsweredYesByAnyone = anyoneSequence.ToArray();
            QuestionsAnsweredYesByEveryone = everyoneSequence.ToArray();
        }

        private string ResolveEveryOneSequence(string everyoneSequence)
        {
            string result = "";
            foreach (var cha in everyoneSequence)
            {
                if (everyoneSequence.Count(c => c == cha) > 1 && !result.Contains(cha))
                {
                    result += cha;
                }
            }

            return result;
        }
    }
}
