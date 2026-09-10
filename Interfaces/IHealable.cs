/// <summary>
/// Defines the ability to heal.
/// </summary>
/// <remarks>
/// Only heroes with healing abilities should implement this interface.
/// </remarks>
public interface IHealable
{
    /// <summary>
    /// Heals a target.
    /// </summary>
    /// <param name="target">The name of the target to heal.</param>
    /// <returns>A description of the healing action.</returns>
    string Heal(string target);
}