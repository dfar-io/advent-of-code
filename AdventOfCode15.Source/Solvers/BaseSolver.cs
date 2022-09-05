using System.Collections.Generic;

public abstract class BaseSolver
{
    protected int _answer1;
    protected int _answer2;
    protected string[] _input;
    public int Answer1 => _answer1;
    public int Answer2 => _answer2;


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