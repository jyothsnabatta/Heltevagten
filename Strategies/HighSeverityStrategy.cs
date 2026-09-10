using System.Collections.Generic;
/// <summary>
/// Selects a hero based on the severity of the incident.
/// </summary>
public class HighSeverityStrategy : IDispatchStrategy
{
    /// <summary>
    /// Selects an available hero for a high-severity incident.
    /// </summary>
    /// <param name="incident">The incident to handle.</param>
    /// <param name="availableHeroes">The available heroes.</param>
    /// <returns>The selected hero.</returns>
    /// <exception cref="NoSuitableHeroFoundException">
    /// Thrown when no suitable hero is available.
    /// </exception>
    public Hero SelectHero(
        Incident incident,
        List<Hero> availableHeroes)
    {
        if (incident.Severity != Severity.High)
        {
            return availableHeroes.Count > 0
                ? availableHeroes[0]
                : throw new NoSuitableHeroFoundException(
                    "No available hero was found for this incident.");
        }

        if (availableHeroes.Count == 0)
        {
            throw new NoSuitableHeroFoundException(
                "No available hero was found for this incident.");
        }

        // For a high-severity incident, choose the strongest
        // available hero.
        Hero strongestHero = availableHeroes[0];

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
