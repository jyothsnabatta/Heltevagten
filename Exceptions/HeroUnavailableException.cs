using System;

/// <summary>
/// Exception thrown when a hero is not available for dispatch.
/// </summary>
public class HeroUnavailableException : Exception
{
    /// <summary>
    /// Creates a new HeroUnavailableException.
    /// </summary>
    /// <param name="message">The error message.</param>
    public HeroUnavailableException(string message)
        : base(message)
    {
    }
}