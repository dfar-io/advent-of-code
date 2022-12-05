using System.Collections.Generic;

public abstract class BaseSolver
{
    public BaseSolver(string input)
    {
        Input = new string[1] { input };

        Answer1 = string.Empty;
        Answer2 = string.Empty;
    }

    public BaseSolver(string[] input)
    {
        Input = input;

        Answer1 = string.Empty;
        Answer2 = string.Empty;
    }

    public string[] Input { get; private set; }

    public string Answer1 { get; set; }

    public string Answer2 { get; set; }
}