using System;

public class PlayersException : Exception
{
    public int Value { get; }
    public PlayersException(string message, int Value) : base(message)
    {
        this.Value = Value;
    }
}
