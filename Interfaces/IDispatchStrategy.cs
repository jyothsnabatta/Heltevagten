using System.Collections.Generic;

/// <summary>
/// Defines how the dispatch center selects a hero for an incident.
/// </summary>
/// <remarks>
/// Using an interface keeps the dispatch center loosely coupled.
/// Different hero-selection strategies can be created later.
/// </remarks>
public interface IDispatchStrategy
{
    /// <summary>
    /// Selects a suitable hero for an incident.
    /// </summary>
    /// <param name="incident">The incident that needs help.</param>
    /// <param name="availableHeroes">The heroes currently available.</param>
    /// <returns>The selected hero.</returns>
    Hero SelectHero(Incident incident, List<Hero> availableHeroes);
}