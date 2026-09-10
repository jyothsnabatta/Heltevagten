/// <summary>
/// Defines the ability to fly.
/// </summary>
/// <remarks>
/// Only heroes that can fly should implement this interface.
/// </remarks>
public interface IFlyable
{
    /// <summary>
    /// Makes the hero fly to a specified location.
    /// </summary>
    /// <param name="location">The destination location.</param>
    void FlyTo(string location);
}