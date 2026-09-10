/// <summary>
/// Represents the common base class for all heroes.
/// </summary>
/// <remarks>
/// Hero is an abstract class, so we cannot create a Hero object directly.
/// The different hero types inherit from this class and provide
/// their own implementation of UseSignatureMove().
/// </remarks>
public abstract class Hero
{
    // The name of the hero.
    public string Name { get; }

    // The hero's energy level.
    // private set means other classes can read it,
    // but they cannot change it directly.
    public int EnergyLevel { get; private set; }

    // Shows whether the hero is available for a new incident.
    // private set protects the value from being changed directly
    // by other classes.
    public bool IsAvailable { get; private set; }

    /// <summary>
    /// Creates a new hero.
    /// </summary>
    /// <param name="name">The name of the hero.</param>
    /// <param name="energyLevel">The starting energy level of the hero.</param>
    protected Hero(string name, int energyLevel)
    {
        Name = name;
        EnergyLevel = energyLevel;
        IsAvailable = true;
    }

    /// <summary>
    /// Performs the hero's special signature move.
    /// </summary>
    /// <returns>A description of the signature move.</returns>
    /// <remarks>
    /// This method is abstract because each type of hero
    /// must implement its own version of the move.
    /// </remarks>
    public abstract string UseSignatureMove();

    /// <summary>
    /// Uses some of the hero's energy.
    /// </summary>
    /// <param name="amount">The amount of energy to use.</param>
    public void UseEnergy(int amount)
    {
        EnergyLevel -= amount;

        // Make sure the energy level does not become negative.
        if (EnergyLevel < 0)
        {
            EnergyLevel = 0;
        }
    }

    /// <summary>
    /// Restores some of the hero's energy.
    /// </summary>
    /// <param name="amount">The amount of energy to restore.</param>
    public void RestoreEnergy(int amount)
    {
        if (amount > 0)
        {
            EnergyLevel += amount;
        }
    }

    /// <summary>
    /// Changes whether the hero is available for dispatch.
    /// </summary>
    /// <param name="available">
    /// True if the hero is available; otherwise false.
    /// </param>
    internal void SetAvailability(bool available)
    {
        IsAvailable = available;
    }
}

