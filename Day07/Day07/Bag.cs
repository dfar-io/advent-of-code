using System;

namespace Day07
{
    public class Bag
    {
        public string Color { get; private set; }

        public Bag(string data)
        {   
            var bagsIndex = data.IndexOf("bag");
            Color = data.Substring(0, bagsIndex - 1);
        }
    }
}
