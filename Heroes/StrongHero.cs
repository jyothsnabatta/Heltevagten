/// <summary>
/// Represents a hero with enhanced physical strength.
/// </summary>
/// <remarks>
/// StrongHero inherits from Hero and implements ISuperStrong.
/// </remarks>
public class StrongHero : Hero, ISuperStrong
{
    /// <summary>
    /// Creates a new strong hero.
    /// </summary>
    /// <param name="name">The name of the hero.</param>
    /// <param name="energyLevel">The starting energy level.</param>
    public StrongHero(string name, int energyLevel)
        : base(name, energyLevel)
    {
    }

    /// <summary>
    /// Performs the strong hero's signature move.
    /// </summary>
    /// <returns>A description of the strength action.</returns>
    public override string UseSignatureMove()
    {
        return $"{Name} uses super strength to protect others.";
    }

    /// <summary>
    /// Uses the hero's super strength.
    /// </summary>
    /// <returns>A description of the strength action.</returns>
    public string UseSuperStrength()
    {
        return $"{Name} uses super strength.";
    }
}