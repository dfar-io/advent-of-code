using System.Collections.Generic;

public abstract class BaseSolver
{
    protected string[] _input;

    public BaseSolver(string input)
    {
        _input = new string[1];
        _input[0] = input;

        Answer1 = string.Empty;
        Answer2 = string.Empty;
    }

    public BaseSolver(string[] input)
    {
        _input = input;

        Answer1 = string.Empty;
        Answer2 = string.Empty;
    }

    public string Answer1 { get; set; }

    public string Answer2 { get; set; }
}