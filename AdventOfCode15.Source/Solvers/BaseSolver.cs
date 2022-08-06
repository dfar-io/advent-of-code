using System.Collections.Generic;

public abstract class BaseSolver
{
    protected string[] _input;
    public abstract int Answer1
    {
        get;
    }
    public abstract int Answer2
    {
        get;
    }


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