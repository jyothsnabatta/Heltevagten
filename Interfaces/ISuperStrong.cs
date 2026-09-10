/// <summary>
/// Defines the ability to use super strength.
/// </summary>
/// <remarks>
/// Only heroes with special strength abilities should implement
/// this interface.
/// </remarks>
public interface ISuperStrong
{
    /// <summary>
    /// Uses super strength.
    /// </summary>
    /// <returns>A description of the strength action.</returns>
    string UseSuperStrength();
}