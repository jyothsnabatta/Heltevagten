/// <summary>
/// Represents a hero with the ability to fly.
/// </summary>
/// <remarks>
/// FlyingHero inherits from Hero and provides its own
/// implementation of the signature move.
/// </remarks>
public class FlyingHero : Hero
{
    /// <summary>
    /// Creates a new flying hero.
    /// </summary>
    /// <param name="name">The name of the hero.</param>
    /// <param name="energyLevel">The starting energy level.</param>
    public FlyingHero(string name, int energyLevel)
        : base(name, energyLevel)
    {
    }

    /// <summary>
    /// Performs the flying hero's signature move.
    /// </summary>
    /// <returns>A description of the flying action.</returns>
    public override string UseSignatureMove()
    {
        return $"{Name} flies quickly to the incident.";
    }
}