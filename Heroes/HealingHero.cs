/// <summary>
/// Represents a hero with healing abilities.
/// </summary>
/// <remarks>
/// HealingHero inherits from Hero and implements IHealable.
/// </remarks>
public class HealingHero : Hero, IHealable
{
    /// <summary>
    /// Creates a new healing hero.
    /// </summary>
    /// <param name="name">The name of the hero.</param>
    /// <param name="energyLevel">The starting energy level.</param>
    public HealingHero(string name, int energyLevel)
        : base(name, energyLevel)
    {
    }

    /// <summary>
    /// Performs the healing hero's signature move.
    /// </summary>
    /// <returns>A description of the healing action.</returns>
    public override string UseSignatureMove()
    {
        return $"{Name} uses healing power to help others.";
    }

    /// <summary>
    /// Heals a specified target.
    /// </summary>
    /// <param name="target">The name of the target to heal.</param>
    /// <returns>A description of the healing action.</returns>
    public string Heal(string target)
    {
        return $"{Name} heals {target}.";
    }
}