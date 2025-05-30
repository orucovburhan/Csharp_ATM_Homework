namespace homework5_Bank;
using System;

public class PINCanNotMatchException : Exception
{
    public PINCanNotMatchException()
    {
    }

    public PINCanNotMatchException(string message)
        : base(message)
    {
    }

    public PINCanNotMatchException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}