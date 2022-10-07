using System.Collections.Generic;

public abstract class BaseSolver
{
    protected string? _answer1;
    protected string? _answer2;
    protected string[] _input;
    public string Answer1 => _answer1 ?? "";
    public string Answer2 => _answer2 ?? "";


    public BaseSolver(string input)
    {
        _input = new string[1];
        _input[0] = input;
    }

    public BaseSolver(string[] input)
    {
        _input = input;
    }
}