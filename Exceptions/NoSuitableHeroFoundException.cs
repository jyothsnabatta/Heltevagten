using System;

/// <summary>
/// Exception thrown when no suitable hero can be found for an incident.
/// </summary>
public class NoSuitableHeroFoundException : Exception
{
    /// <summary>
    /// Creates a new NoSuitableHeroFoundException.
    /// </summary>
    /// <param name="message">The error message.</param>
    public NoSuitableHeroFoundException(string message)
        : base(message)
    {
    }
}