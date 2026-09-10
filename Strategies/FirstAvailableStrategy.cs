using System.Collections.Generic;

/// <summary>
/// Selects the first available hero for an incident.
/// </summary>
/// <remarks>
/// This is the first implementation of IDispatchStrategy.
/// The strategy can later be replaced with another strategy
/// without changing the DispatchCenter.
/// </remarks>
public class FirstAvailableStrategy : IDispatchStrategy
{
    /// <summary>
    /// Selects the first available hero.
    /// </summary>
    /// <param name="incident">The incident that needs help.</param>
    /// <param name="availableHeroes">The available heroes.</param>
    /// <returns>The first available hero.</returns>
    /// <exception cref="NoSuitableHeroFoundException">
    /// Thrown when no available hero can be found.
    /// </exception>
    public Hero SelectHero(Incident incident, List<Hero> availableHeroes)
    {
        foreach (Hero hero in availableHeroes)
        {
            if (hero.IsAvailable)
            {
                return hero;
            }
        }

        throw new NoSuitableHeroFoundException(
            "No available hero was found for this incident.");
    }
}