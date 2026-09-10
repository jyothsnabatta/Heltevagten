using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Manages heroes and emergency incidents.
/// </summary>
public class DispatchCenter
{
    // Stores all registered heroes.
    private readonly List<Hero> _heroes = new List<Hero>();

    // Stores all reported incidents.
    private readonly List<Incident> _incidents = new List<Incident>();

    // Defines how heroes are selected.
    private readonly IDispatchStrategy _dispatchStrategy;

    /// <summary>
    /// Creates a new dispatch center.
    /// </summary>
    /// <param name="dispatchStrategy">
    /// The strategy used to select heroes.
    /// </param>
    public DispatchCenter(IDispatchStrategy dispatchStrategy)
    {
        _dispatchStrategy = dispatchStrategy;
    }

    /// <summary>
    /// Registers a hero in the dispatch center.
    /// </summary>
    /// <param name="hero">The hero to register.</param>
    public void RegisterHero(Hero hero)
    {
        _heroes.Add(hero);
    }

    /// <summary>
    /// Reports a new incident.
    /// </summary>
    /// <param name="incident">The incident to report.</param>
    public void ReportIncident(Incident incident)
    {
        _incidents.Add(incident);
    }

    /// <summary>
    /// Assigns an available hero to an incident.
    /// </summary>
    /// <param name="incident">The incident that needs help.</param>
    /// <returns>The selected hero.</returns>
    public Hero AssignHero(Incident incident)
    {
        List<Hero> availableHeroes = _heroes
            .Where(hero => hero.IsAvailable)
            .ToList();

        Hero selectedHero = _dispatchStrategy
            .SelectHero(incident, availableHeroes);

        if (!selectedHero.IsAvailable)
        {
            throw new HeroUnavailableException(
                $"{selectedHero.Name} is not available.");
        }

        selectedHero.SetAvailability(false);

        return selectedHero;
    }

    /// <summary>
    /// Assigns a specific hero to an incident.
    /// </summary>
    /// <param name="hero">The hero to assign.</param>
    /// <param name="incident">The incident that needs help.</param>
    /// <returns>The assigned hero.</returns>
    /// <exception cref="HeroUnavailableException">
    /// Thrown when the selected hero is not available.
    /// </exception>
    public Hero AssignSpecificHero(Hero hero, Incident incident)
    {
        if (!hero.IsAvailable)
        {
            throw new HeroUnavailableException(
                $"{hero.Name} is not available.");
        }

        hero.SetAvailability(false);

        return hero;
    }

    /// <summary>
    /// Finds the first item that matches the given condition.
    /// </summary>
    /// <typeparam name="T">The type of item to search.</typeparam>
    /// <param name="items">The collection to search.</param>
    /// <param name="predicate">The condition used for searching.</param>
    /// <returns>The first matching item, or the default value.</returns>
    public T FindFirst<T>(List<T> items, Func<T, bool> predicate)
    {
        foreach (T item in items)
        {
            if (predicate(item))
            {
                return item;
            }
        }

        return default(T);
    }

    /// <summary>
    /// Resolves an incident and calls the supplied callback.
    /// </summary>
    /// <param name="incident">The incident to resolve.</param>
    /// <param name="onResolved">The callback to execute.</param>
    public void ResolveIncident(
        Incident incident,
        Action<Incident> onResolved)
    {
        incident.Resolve();
        onResolved(incident);
    }
}

