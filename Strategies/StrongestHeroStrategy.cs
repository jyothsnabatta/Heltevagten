using System.Collections.Generic;

/// <summary>
/// Selects the strongest available hero for an incident.
/// </summary>
/// <remarks>
/// This is a second implementation of IDispatchStrategy.
/// It selects the available hero with the highest energy level.
/// </remarks>
public class StrongestHeroStrategy : IDispatchStrategy
{
    /// <summary>
    /// Selects the strongest available hero.
    /// </summary>
    /// <param name="incident">The incident that needs help.</param>
    /// <param name="availableHeroes">The available heroes.</param>
    /// <returns>The hero with the highest energy level.</returns>
    /// <exception cref="NoSuitableHeroFoundException">
    /// Thrown when no available hero can be found.
    /// </exception>
    public Hero SelectHero(
        Incident incident,
        List<Hero> availableHeroes)
    {
        if (availableHeroes.Count == 0)
        {
            throw new NoSuitableHeroFoundException(
                "No available hero was found for this incident.");
        }

        // Start with the first available hero.
        Hero strongestHero = availableHeroes[0];

        // Find the hero with the highest energy level.
        foreach (Hero hero in availableHeroes)
        {
            if (hero.EnergyLevel > strongestHero.EnergyLevel)
            {
                strongestHero = hero;
            }
        }

        return strongestHero;
    }
}