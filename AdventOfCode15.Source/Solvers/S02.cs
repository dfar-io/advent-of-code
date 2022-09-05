using System;

public class S02 : BaseSolver
{
    public S02(string[] input) : base(input)
    {
        foreach (var dimensions in _input)
        {
            var dim = dimensions.Split('x');
            var length = int.Parse(dim[0]);
            var width = int.Parse(dim[1]);
            var height = int.Parse(dim[2]);

            var area1 = 2 * length * width;
            var area2 = 2 * width * height;
            var area3 = 2 * height * length;
            _answer1 += area1 + area2 + area3 + Math.Min(area1, Math.Min(area2, area3)) / 2;
            _answer2 += 2 * length
                    + 2 * width
                    + 2 * height
                    - 2 * Math.Max(length, Math.Max(width, height))
                    + length * width * height;
        }
    }
}